﻿using DaprTest.Domain.Entities.Admins;
using DaprTest.EFCore;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer
{
    public class ProfileService : IProfileService
    {
        private readonly AdminDbContext _adminDbContext;
        public ProfileService(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string clientId = context.Client.ClientId;
            var client = await _adminDbContext.ApplicationClients.Where(a => a.ClientId == clientId).FirstOrDefaultAsync();
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("ClientType", client.ClientType.ToString()));
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string clientType = context.Subject?.Claims.FirstOrDefault(a => a.Type == "ClientType")?.Value;
            string clientId = context.Client.ClientId;
            var client =await _adminDbContext.ApplicationClients.Where(a => a.ClientId == clientId).FirstOrDefaultAsync();
            if (client.ClientType.ToString() != clientType)
            {
                context.IsActive = false;
            }
            //context.Client.
            //throw new NotImplementedException();
        }
    }
}
