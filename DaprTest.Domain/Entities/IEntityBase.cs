using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities
{
    interface IEntityBase
    {
        int Id { get; set; }
        DateTime CreatTime { get; set; }
        DateTime UpdateTime { get; set; }
        bool IsDeleted { get; set; }
    }
    public class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
