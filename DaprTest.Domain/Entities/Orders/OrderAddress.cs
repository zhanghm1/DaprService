using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Orders
{
    public class OrderAddress : EntityBase
    {
        public int MemberId { get; set; }
        public string Address { get; set; }
    }
}
