using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace MeetUp.Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("MeetUpWebApi", "Web Api")
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()

        };

        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {
            new ApiResource("MeetUpWebApi", "Web Api", new [] { JwtClaimTypes.Name })
            {
                Scopes = {"MeetUpWebApi"}
            }

        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "meetup-web-api",
                ClientName = "MeetUp Web Api",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "https://..."
                },
                AllowedCorsOrigins =
                {
                    "https://..."
                },
                PostLogoutRedirectUris =
                {
                    "https://..."
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "MeetUpWebApi"
                },
                AllowAccessTokensViaBrowser = true
            }
        };
    }
}
