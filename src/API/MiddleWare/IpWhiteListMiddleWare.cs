using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace dotnetAPI.MiddleWare
{
    public class IpWhiteListMiddleWare
    {
        private readonly RequestDelegate next;

        public IpWhiteListMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }
        /// <summary>
        /// This Middleware validates allowed IP address if the caller
        /// is NOT authenticated using AD
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            bool IsAuthenticated = context.User.Identity.IsAuthenticated;
            string AuthenticationType = string.Empty;
            // if true we need to test type

            if (IsAuthenticated)
            {
                //AuthenticationType = context.User.Identity.AuthenticationType.ToLower();

                //if ((AuthenticationType == "ntlm" || AuthenticationType == "kerberos"))
                //{
                  
                //}

            }
            else
            {
                var RemoteIpAddress = context.Connection.RemoteIpAddress.ToString(); //  returns  ::1 if local
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                bool IsIpInWhiteList = new[] { "serverip", "::1", "string3" }.Contains(RemoteIpAddress);

                if (!IsIpInWhiteList)
                {
                    // if not in list send 401 unauthorised
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }

            // get the type of authentication
         
            await next(context);
        }
    }
}
