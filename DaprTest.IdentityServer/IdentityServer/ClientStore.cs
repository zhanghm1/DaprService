using DaprTest.EFCore;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer
{
    public class ClientStore : IClientStore
    {
        private AdminDbContext _adminDbContext;
        public ClientStore(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
           var dbClient = await _adminDbContext.ApplicationClients.FirstOrDefaultAsync(a=>a.ClientId==clientId);
            //throw new NotImplementedException();

            var client = new Client()
            {
                ClientId = dbClient.ClientId,
                ClientSecrets = { new Secret(dbClient.ClientSecert.Sha256()) },
                RequireClientSecret=dbClient.RequireClientSecret,
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { dbClient.RedirectUris },
                PostLogoutRedirectUris = { dbClient.LogoutRedirectUris },
                AllowedScopes = dbClient.AllowedScopes.Split(" "),
            };

            return client;

        }
    }
}
