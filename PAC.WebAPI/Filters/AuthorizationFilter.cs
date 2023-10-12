using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (authorizationHeader != "true")
            {
                context.Result = new ObjectResult(new { Message = "No puedo authorizarme" })
                {
                    StatusCode = 401
                };
            }
        }
    }

}

