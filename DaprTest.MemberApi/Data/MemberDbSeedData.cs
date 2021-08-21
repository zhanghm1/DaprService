using DaprTest.Application.AccountServices;
using DaprTest.Domain;
using DaprTest.Domain.BaseModels;
using DaprTest.Domain.Data;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Domain.Entities.Members;
using DaprTest.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.MemberApi.Data
{
    public class MemberDbSeedData:IDbSeedData
    {
        private IAccountManage<Member, MemberDbContext> _accountManage;
        public MemberDbSeedData(IAccountManage<Member, MemberDbContext> accountManage)
        {
            _accountManage = accountManage;
        }

        public async Task Init()
        {
            foreach (var item in MemberData.List)
            {
                if (!await _accountManage.AnyByUserName(item.UserName))
                {
                    var member = new Member()
                    {
                        UserName = item.UserName,
                        Email = item.Email,
                        Name = item.Name,
                        PhoneNumber = item.PhoneNumber,
                    };
                    await _accountManage.Create(member, item.Password);
                }
            }

        }
    }
}
