using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain
{
    public interface IEntityIdBase
    {
        string Id { get; set; }
    }
    interface IEntityBase: IEntityIdBase
    {
        DateTime CreatTime { get; set; }
        DateTime UpdateTime { get; set; }
        bool IsDeleted { get; set; }
    }
    interface IEntityTenantBase
    {
        string TenantCode { get; set; }
    }
    public class EntityBase : IEntityBase
    {
        /// <summary>
        /// ID,统一小写
        /// </summary>
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
    /// <summary>
    /// 带商户的基础实体
    /// </summary>
    public class EntityTenantBase : EntityBase, IEntityTenantBase
    {
        public string TenantCode { get; set; }
    }
}
