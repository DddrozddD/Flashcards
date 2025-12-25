using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Flashcards.Identity
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("FlashcardsWebApi", "Flashcards Web API")
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("FlashcardsWebApi", "Flashcards Web API", new [] { "name" })
                {
                    Scopes = { "FlashcardsWebApi" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
               new Client
               {
                   ClientId = "flashcards-web-app",
                   ClientName = "Flashcards Web Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                   RequireClientSecret = false,
                   RequirePkce = true,
                   RedirectUris = { "https://localhost:5173/signin-oidc" }, 
                   PostLogoutRedirectUris = { "https://localhost:5173/signout-oidc" },
                   AllowedCorsOrigins = { "https://localhost:5173" },
                   AllowedScopes =
                   {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       "FlashcardsWebApi" 
                   },
                   AllowAccessTokensViaBrowser = true
               },
               new Client
               {
                     ClientId = "flashcards-api-swagger",
                     ClientName = "Flashcards API Swagger UI",


                     AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                     RequireClientSecret = false,
                     RequirePkce = true,
    
                     RedirectUris = { "https://localhost:7172/swagger/oauth2-redirect.html" },
                     AllowedCorsOrigins = { "https://localhost:7172" },
                     AllowedScopes =
                     {
                          IdentityServerConstants.StandardScopes.OpenId,
                          IdentityServerConstants.StandardScopes.Profile,
                          "FlashcardsWebApi"
                     },
                     AllowAccessTokensViaBrowser = true
               }
            };
    }
}