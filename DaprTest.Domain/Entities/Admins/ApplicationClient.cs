using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Admins
{
    public class ApplicationClient : EntityTenantBase
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ClientSecert { get; set; }
        public string RedirectUris { get; set; }
        public string LogoutRedirectUris { get; set; }
        public string AllowedScopes { get; set; }
        public bool RequireClientSecret { get; set; } = true;
        public ClientType ClientType { get; set; }
    }

    public enum ClientType
    { 
        /// <summary>
        /// 会员客户端
        /// </summary>
        MemberClient,
        /// <summary>
        /// 商户客户端
        /// </summary>
        TenantClient,
        /// <summary>
        /// 管理员客户端
        /// </summary>
        AdminClient
    }
}
