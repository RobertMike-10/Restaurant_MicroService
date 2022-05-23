using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Restaurant.Services.Identity
{
    public static class Constants
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
        {
            new ApiScope("Restaurant","RestaurantServer"),
            new ApiScope(name:"read",displayName:"Read data"),
            new ApiScope(name:"write",displayName:"Write data"),
            new ApiScope(name:"delete",displayName:"Delete data")
        };
        //client apps, mobile, web, etc
        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client {
                ClientId="ClientWeb",
                ClientSecrets={new Secret("secretBecky".Sha256()) },
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                AllowedScopes={ "read", "write", "Restaurant","profile" }
            },
             new Client {
                ClientId="Restaurant",
                ClientSecrets={new Secret("secretBecky".Sha256()) },
                AllowedGrantTypes= GrantTypes.Code,   
                RedirectUris = { "https://localhost:7106/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:7106/signout-callback-oidc" },
                AllowedScopes=new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "Restaurant"
                }
            }
        };


    }
}
