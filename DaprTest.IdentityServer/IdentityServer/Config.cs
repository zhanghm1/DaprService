using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("orderapi", "My API"),
                new ApiScope("productapi", "My API"),
                new ApiScope("memberapi", "My API"),
            };
        public static IEnumerable<Client> Clients(IConfiguration Configuration)
        {
            string MVCUrl = Configuration["MVCUrl"];
            string JSUrl = Configuration["JSUrl"];
            return new List<Client>
            {
                 new Client
                    {
                        ClientId = "mvc",
                        ClientSecrets = { new Secret("secret".Sha256()) },

                        AllowedGrantTypes = GrantTypes.Code,
                    
                        // where to redirect to after login
                        RedirectUris = { MVCUrl+"/signin-oidc" },

                        // where to redirect to after logout
                        PostLogoutRedirectUris = { MVCUrl + "/signout-callback-oidc" },

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "orderapi",
                            "productapi",
                            "memberapi",
                        }
                    },
                 new Client
                    {
                        ClientId = "js",
                        ClientName = "JavaScript Client",
                        AllowedGrantTypes = GrantTypes.Code,
                        RequireClientSecret = false,

                        RedirectUris =           { JSUrl+"/callback.html" },
                        PostLogoutRedirectUris = { JSUrl+"/index.html" },
                        AllowedCorsOrigins =     { JSUrl },

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "orderapi",
                            "productapi",
                            "memberapi",
                        }
                    }
            };
        }
    }
}
