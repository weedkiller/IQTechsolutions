using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace IQTechSolutions.Web.Identity
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
                ClientSecrets = { new Secret("9dddc004-e683-4497-a79f-651db6922570".ToSha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "MainApi" }
            },
            new Client()
            {
                ClientId = "Website_Public",
                ClientSecrets = { new Secret("c495bd54-4cac-4a48-bc66-d85fca033294".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris =
                {
                    "https://localhost:7001/signin-oidc"
                },
                AllowedScopes = { "MainApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            },
            new Client()
            {
                ClientId = "Website_Admin",
                ClientSecrets = { new Secret("089e63c9-b451-4a23-8d94-81891cdcfe8d".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris =
                {
                    "https://localhost:6001/signin-oidc"
                },
                AllowedScopes = { "MainApi", IdentityServer4.IdentityServerConstants.StandardScopes.OpenId, IdentityServer4.IdentityServerConstants.StandardScopes.Profile }
            }
        };
    }
}
