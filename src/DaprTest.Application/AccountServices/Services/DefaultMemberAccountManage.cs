using DaprTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Application.AccountServices
{
    public class DefaultAccountManage<TAccount, TDbContext> : IAccountManage<TAccount, TDbContext>

        where TAccount : class,IUserBase
        where TDbContext : DbContext
    {
        private TDbContext _dbContext;
        private DbSet<TAccount> _account;
        private IPasswordHandler _passwordHandler;
        public DefaultAccountManage(IPasswordHandler passwordHandler, TDbContext dbContext)
        {
            _passwordHandler = passwordHandler;
            _dbContext = dbContext;
            _account = _dbContext.Set<TAccount>();
        }
        public async Task<bool> Create(TAccount account, string password)
        {
            account.PasswordSecert = _passwordHandler.GetPasswordSecert();
            account.PasswordHash = _passwordHandler.GetPasswordHash(account.PasswordSecert, password);

            await _account.AddAsync(account);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> AnyByUserName(string userName)
        {
            return await _account.AnyAsync(a => a.UserName == userName);
        }
        public async Task<bool> AnyById(string id)
        {
            return await _account.AnyAsync(a => a.Id == id);
        }
        public async Task<TAccount> GetAccountById(string id)
        {
           return await _account.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<TAccount> GetAccountByUserName(string userName)
        {
            return await _account.FirstOrDefaultAsync(a => a.UserName == userName);
        }
        public async Task<TAccount> GetAccountByPhone(string phone)
        {
            return await _account.FirstOrDefaultAsync(a => a.PhoneNumber == phone);
        }
        public async Task<TAccount> GetAccountByEmail(string email)
        {
            return await _account.FirstOrDefaultAsync(a => a.Email == email);
        }

        public bool CheckPassword(TAccount account, string password)
        {
           return _passwordHandler.VerifyPassword(account.PasswordHash, account.PasswordSecert, password);
        }
    }
}
