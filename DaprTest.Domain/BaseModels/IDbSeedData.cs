using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.BaseModels
{
    public interface IDbSeedData
    {
        Task Init();
    }
}
