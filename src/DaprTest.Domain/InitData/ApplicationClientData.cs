using DaprTest.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Data
{
    public class ApplicationClientData
    {
        public static string DefaultClientSecert = "secret";
        public static string DefaultAdminMangeClientId = "AdminManage";
        public static string DefaultTenantMangeClientId = "TenantManage";
        public static string DefaultProductWebClientId = TenantInfoData.DefaultTenantCode+"Web";
        public static List<ApplicationClient> List = new List<ApplicationClient>() {
                new ApplicationClient()
                {

                    Name="管理后台",
                    ClientId=DefaultAdminMangeClientId,
                    ClientSecert=DefaultClientSecert,
                    ClientType= ClientType.AdminClient,
                    TenantCode=null,
                    RedirectUris="/signin-oidc",
                    LogoutRedirectUris="/signout-callback-oidc",
                    AllowedScopes="openid profile orderapi productapi memberapi payapi storeapi tenantapi",

                },
                new ApplicationClient()
                {

                    Name="商户管理后台",
                    ClientId=DefaultTenantMangeClientId,
                    ClientSecert=DefaultClientSecert,
                    ClientType= ClientType.TenantClient,
                    TenantCode=null,
                    RequireClientSecret=false,
                    RedirectUris="/callback.html",
                    LogoutRedirectUris="/index.html",
                    AllowedCorsOrigins="",
                    AllowedScopes="openid profile orderapi productapi memberapi payapi storeapi tenantapi",
                },
                new ApplicationClient()
                {

                    Name="展示产品前台",
                    ClientId=DefaultProductWebClientId,
                    ClientSecert=DefaultClientSecert,
                    RequireClientSecret=false,
                    ClientType= ClientType.MemberClient,
                    TenantCode=TenantInfoData.DefaultTenantCode,
                    RedirectUris="/callback.html",
                    LogoutRedirectUris="/index.html",
                    AllowedCorsOrigins="",
                    AllowedScopes="openid profile orderapi productapi memberapi payapi storeapi",

                },
            };
    }
}
