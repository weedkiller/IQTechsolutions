using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace FeawThings.Web.Identity
{
    public static class IdentityConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>()
        {
            new ApiResource("MainApi")
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
        {
            new ApiScope("MainApi")
        };

        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("5e858927-6bbd-4137-9131-434e166a3143".ToSha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "MainApi" }
            },
            new Client()
            {
                ClientId = "Website_Public",
                ClientSecrets = { new Secret("b51fb636-8553-4228-ae5c-bc62e7e98c94".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { ServerLocations.WebServer + "/signin-oidc" },
                PostLogoutRedirectUris = { ServerLocations.WebServer + "/Home/Index" },

                AllowedScopes = { "MainApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            },
            new Client()
            {
                ClientId = "Website_Admin",
                ClientSecrets = { new Secret("88e3ca5b-a99b-47dd-b109-83807a52ad5d".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { ServerLocations.AdminServer + "/signin-oidc" },
                PostLogoutRedirectUris = { ServerLocations.AdminServer + "/Home/Index" },

                AllowedScopes = { "MainApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            },
            new Client()
            {
                ClientId = "Website_Clients",
                ClientSecrets = { new Secret("babce26e-9f7b-44ae-8379-bf051d47a86b".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { ServerLocations.ClientServer + "/signin-oidc" },
                PostLogoutRedirectUris = { ServerLocations.ClientServer + "/Home/Index" },

                AllowedScopes = { "MainApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            }
        };
    }
}
