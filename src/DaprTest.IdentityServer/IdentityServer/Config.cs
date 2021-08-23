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
                new ApiScope("orderapi", "订单服务"),
                new ApiScope("payapi", "支付服务"),
                new ApiScope("productapi", "商品服务"),
                new ApiScope("memberapi", "会员服务"),
                new ApiScope("storeapi", "门店服务"),
                new ApiScope("tenantapi", "商户服务"),
            };
        public static IEnumerable<Client> Clients(IConfiguration Configuration)
        {
            string MVCUrl = Configuration["MVCUrl"];
            string JSUrl = Configuration["JSUrl"];
            return new List<Client>
            {
                 new Client
                    {
                        ClientId = "admin",
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
                            "payapi",
                            "productapi",
                            "memberapi",
                            "storeapi",
                            "tenantapi",
                        }
                    },
                 new Client
                    {
                        ClientId = "productjs",
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
                    },
                 new Client
                    {
                        ClientId = "tenantjs",
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
