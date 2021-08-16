using DaprTest.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Application.MemberServices
{
    public interface IMemberAccountManage
    {
        Task<bool> Create(Member member,string password);
        Task<Member> GetMemberById(int id);
        Task<Member> GetMemberByPhone(string phone);
        Task<Member> GetMemberByEmail(string email);
        Task<Member> GetMemberByUserName(string userName);
        Task<bool> AnyByUserName(string userName);
        Task<bool> AnyById(int id);
        
    }
}
