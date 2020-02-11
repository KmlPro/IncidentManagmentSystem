using System;
using BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;

namespace IncidentManagmentSystem.Web.Users
{
    // kbytner 11.02.2020 - temp implementation, now without user
    public class CurrentUserContext : ICurrentUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId => new Guid("bf52748c-0199-4f82-b170-c6d7910ecef6");
    }
}
