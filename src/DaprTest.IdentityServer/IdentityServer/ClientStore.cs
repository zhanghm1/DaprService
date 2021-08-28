using Dapr.Client;
using DaprTest.Domain.Entities.Admins;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer
{
    public class ClientStore : IClientStore
    {
        private readonly DaprClient _daprClient;
        public ClientStore(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
           var dbClient = await _daprClient.InvokeMethodAsync<ApplicationClient>(HttpMethod.Get, "adminapi", "login/client?clientId="+ clientId);

            var client = new Client()
            {
                ClientId = dbClient.ClientId,
                ClientSecrets = { new Secret(dbClient.ClientSecert.Sha256()) },
                RequireClientSecret=dbClient.RequireClientSecret,
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { dbClient.RedirectUris },
                PostLogoutRedirectUris = { dbClient.LogoutRedirectUris },
                AllowedCorsOrigins= { dbClient.AllowedCorsOrigins },
                AllowedScopes = dbClient.AllowedScopes.Split(" "),
            };

            return client;

        }
    }
}
