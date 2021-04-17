using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace oauthServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                Enabled = true,
                ClientId = "ab53f0a5-f502-41d3-9a09-efcb4558e3c1",
                ProtocolType = "oidc",
                RequireClientSecret = true,
                ClientName = "Default",
                Description = "Default client for Statelogic apps",
                RequireConsent = false,
                AllowRememberConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                RequirePkce = false,
                ClientSecrets =
                {
                    new Secret("P@55w0rd".Sha256())
                },
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Address,
                    "READ"
                },
                RedirectUris = { "https://localhost:8080/callback" },
                AccessTokenType = AccessTokenType.Jwt                
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("READ"), new ApiScope("WRITE")
        };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(), 
            new IdentityResources.Profile(), 
            new IdentityResources.Address(),
            new IdentityResources.Email(),
            new IdentityResources.Phone()
        };

        public static List<TestUser> TestUsers => new List<TestUser>
        {
            new TestUser
            {
                Username = "rsharnagare@gmail.com",                              
                Password = "root",
                SubjectId = "subject id",
                IsActive = true,
                ProviderName = "provider name",
                ProviderSubjectId = "provider subject id",
                Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.GivenName, "Root"),
                    new Claim(ClaimTypes.Surname, "Gmail"),
                    new Claim(ClaimTypes.Email, "root@gmail.com"),
                    new Claim(ClaimTypes.Role, "Root")
                }
            }
        };
    }
}
