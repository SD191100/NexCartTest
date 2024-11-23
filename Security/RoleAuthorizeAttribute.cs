using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NexCart.Enums;
using NexCart.Models;
using System;

namespace NexCart.Security
{
    public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserRole[] _roles;

        public RoleAuthorizeAttribute(params UserRole[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || !_roles.Contains(user.Role))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

