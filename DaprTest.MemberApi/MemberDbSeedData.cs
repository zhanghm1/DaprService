using DaprTest.Application.MemberServices;
using DaprTest.Domain;
using DaprTest.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.MemberApi.Data
{
    public class MemberDbSeedData
    {
        private readonly IMemberAccountManage _memberAccountManage;
        public MemberDbSeedData(IMemberAccountManage memberAccountManage)
        {
            _memberAccountManage = memberAccountManage;
        }
        public async Task Init()
        {
           var members = new List<MemberAddDto>() {
                new MemberAddDto(){ 
                Name="管理员",
                UserName="admin",
                Password="123456",
                PhoneNumber="11000000000",
                Email="admin@admin.com"
                }
            };
            foreach (var item in members)
            {
                if (!await _memberAccountManage.AnyByUserName(item.UserName))
                {
                    var member = new Member()
                    {
                        UserName = item.UserName,
                        Email = item.Email,
                        Name = item.Name,
                        PhoneNumber = item.PhoneNumber,
                    };
                    await _memberAccountManage.Create(member, item.Password);
                }
            }
        }
    }

    public class MemberAddDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
