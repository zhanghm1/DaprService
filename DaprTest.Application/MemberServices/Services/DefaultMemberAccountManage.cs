using DaprTest.Domain.Entities.Members;
using DaprTest.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Application.MemberServices
{
    public class DefaultMemberAccountManage : IMemberAccountManage
    {
        private MemberDbContext _dbContext;
        private IPasswordHandler _passwordHandler;
        public DefaultMemberAccountManage(IPasswordHandler passwordHandler, MemberDbContext dbContext)
        {
            _passwordHandler = passwordHandler;
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Member member, string password)
        {
            member.PasswordSecert = _passwordHandler.GetPasswordSecert();
            member.PasswordHash = _passwordHandler.GetPasswordHash(member.PasswordSecert, password);

            await _dbContext.Members.AddAsync(member);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> AnyByUserName(string userName)
        {
            return await _dbContext.Members.AnyAsync(a => a.UserName == userName);
        }
        public async Task<bool> AnyById(int id)
        {
            return await _dbContext.Members.AnyAsync(a => a.Id == id);
        }
        public async Task<Member> GetMemberById(int id)
        {
           return await _dbContext.Members.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Member> GetMemberByUserName(string userName)
        {
            return await _dbContext.Members.FirstOrDefaultAsync(a => a.UserName == userName);
        }
        public async Task<Member> GetMemberByPhone(string phone)
        {
            return await _dbContext.Members.FirstOrDefaultAsync(a => a.PhoneNumber == phone);
        }
        public async Task<Member> GetMemberByEmail(string email)
        {
            return await _dbContext.Members.FirstOrDefaultAsync(a => a.Email == email);
        }
    }
}
