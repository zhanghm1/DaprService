using Dapr.Client;
using DaprTest.Domain.Entities.Admins;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer
{
    public class ProfileService : IProfileService
    {
        private readonly DaprClient _daprClient;
        public ProfileService(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string clientId = context.Client.ClientId;
            var client = await _daprClient.InvokeMethodAsync<ApplicationClient>(HttpMethod.Get, "adminapi", "login/client?clientId=" + clientId);
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("ClientType", client.ClientType.ToString()));
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string clientType = context.Subject?.Claims.FirstOrDefault(a => a.Type == "ClientType")?.Value;
            string clientId = context.Client.ClientId;
            var client = await _daprClient.InvokeMethodAsync<ApplicationClient>(HttpMethod.Get, "adminapi", "login/client?clientId=" + clientId);
            if (client.ClientType.ToString() != clientType)
            {
                context.IsActive = false;
            }
            //context.Client.
            //throw new NotImplementedException();
        }
    }
}
