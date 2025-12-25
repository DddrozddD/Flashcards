using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Flashcards.Persistence;
using Flashcards.Application;
using Flashcards.Application.Common.Mapping;
using System.Reflection;
using Flashcards.Application.Interfaces;
using Flashcards.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Flashcards.WebApi.Services;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);


builder.Services.AddControllers();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IFlashcardsDbContext).Assembly));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddMvc();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("Bearer", options =>
{
    var authority = "https://localhost:7050";
    // Вимикаємо автоматичне завантаження метаданих, бо ми зробимо це вручну
    // Це прибере помилку "Unable to obtain configuration"
    options.Authority = authority;
    options.RequireHttpsMetadata = false;

    // 1. Створюємо клієнт, що ігнорує SSL (як у вашому успішному тесті)
    var handler = new HttpClientHandler();
    handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
    using (var httpClient = new HttpClient(handler))
    {
        // 2. ВРУЧНУ завантажуємо ключі прямо тут і зараз
        // Якщо тут впаде помилка - ми побачимо її при старті програми, а не під час запиту
        Console.WriteLine("Manual fetching of JWKS started...");
        try
        {
            var jwksResponse = httpClient.GetStringAsync($"{authority}/.well-known/openid-configuration/jwks").GetAwaiter().GetResult();
            var keySet = new JsonWebKeySet(jwksResponse);

            // 3. Передаємо завантажені ключі в параметри валідації
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidIssuer = authority,

                // Найголовніше: ми передаємо конкретний список ключів
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = keySet.Keys,
            };
            Console.WriteLine($"Successfully loaded {keySet.Keys.Count} keys manually.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CRITICAL ERROR loading keys: {ex.Message}");
            // Якщо сервер лежить при старті - API не запуститься коректно, 
            // але для розробки це краще, ніж гадати.
        }
    }

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine($"Auth Failed: {context.Exception.Message}");
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("Token validated successfully!");
            return Task.CompletedTask;
        }
    };
}); 
builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);

    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer",
        Name = "Authorization",
        Description = "Authorization token"
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });

   
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.SwaggerEndpoint("swagger/v1/swagger.json", "Flashcards API V1");
        config.OAuthClientId("flashcards-api-swagger");
        config.OAuthScopes("FlashcardsWebApi");
        config.OAuthUsePkce();

    });
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<FlashcardsDbContext>();
        DbInitializer.Initialize(context);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
// ТЕСТОВИЙ БЛОК - ВИДАЛИТИ ПІСЛЯ ПЕРЕВІРКИ
using (var testClient = new HttpClient(new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator }))
{
    try
    {
        Console.WriteLine("Testing connection to IdentityServer...");
        var response = await testClient.GetAsync("https://localhost:7050/.well-known/openid-configuration");
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Connection SUCCESS! Config found: {content.Substring(0, 50)}...");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Connection FAILED: {ex.Message}");
        // Якщо тут помилка - проблема в Firewall, портах або IPv4/IPv6
    }
}
// КІНЕЦЬ ТЕСТОВОГО БЛОКУ
app.Run();
