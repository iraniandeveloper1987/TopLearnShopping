using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TopLearn.Core.Repository.Interfaces.FilterAttributes;

namespace TopLearn.Core.FilterAttributes
{
    public class CheckPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {


        private readonly int _permissionId;

        public CheckPermissionAttribute(int permissionId)
        {
            _permissionId = permissionId;

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userName = context.HttpContext.User.Identity.Name;

                var filterAttributeService = (IFilterAttributeService)context.HttpContext.RequestServices.GetService(typeof(IFilterAttributeService));

                var hasPermission = filterAttributeService.HasPermission(_permissionId, userName);
                if (!hasPermission)
                {
                    context.Result = new RedirectResult("/Login");
                }

            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}
