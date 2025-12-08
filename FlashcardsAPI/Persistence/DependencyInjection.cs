using Flashcards.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connStr = configuration["ConnectStr"];
            services.AddDbContext<FlashcardsDbContext>(options =>
            {
                options.UseSqlServer(connStr);
            });
            services.AddScoped<IFlashcardsDbContext>(provider =>
            (IFlashcardsDbContext)provider.GetService<FlashcardsDbContext>());
            return services;
        }
    }
}
