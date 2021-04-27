using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Metsi.Web.Identity
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
            new ApiResource("MainApi"), new ApiResource("AdminApi")
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
        {
            new ApiScope("MainApi"), new ApiScope("AdminApi")
        };

        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("91e154c9-c39d-40c5-8eb1-d18192287714".ToSha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "MainApi", "AdminApi" }
            },
            new Client()
            {
                ClientId = "Website_Public",
                ClientSecrets = { new Secret("8768acce-8cc8-4697-8fda-2dcc496d6c72".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { ServerLocations.WebServer + "/signin-oidc" },
                PostLogoutRedirectUris = { ServerLocations.WebServer + "/Home/Index" },

                AllowedScopes = { "MainApi", "AdminApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            },
            new Client()
            {
                ClientId = "Website_Admin",
                ClientSecrets = { new Secret("d38a4ad7-2990-4ed0-8889-1f43dea621fc".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { ServerLocations.AdminServer + "/signin-oidc" },
                PostLogoutRedirectUris = { ServerLocations.AdminServer + "/Home/Index" },

                AllowedScopes = { "MainApi", "AdminApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            },
            new Client()
            {
                ClientId = "Website_Training",
                ClientSecrets = { new Secret("1d79825e-31a1-400f-b38d-83f3bac47263".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { ServerLocations.TrainingServer + "/signin-oidc" },
                PostLogoutRedirectUris = { ServerLocations.TrainingServer + "/Home/Index" },

                AllowedScopes = { "MainApi", "AdminApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            }
        };
    }
}
