using Merino.config;
using Merino.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Merino.Dto;
using System;

namespace Merino.Controller
{

    [CustomExceptionFilter]
    [TypeFilter(typeof(AccessLogFilter))]
    public class MerinoController : Microsoft.AspNetCore.Mvc.Controller
    {

        public MerinoController()
        {
        }

        /// <summary>
        /// 認証cookieをレスポンスに追加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        async public void AddCookie<T>(T dto)
        {
            List<Claim> claimList = new List<Claim>();

            var t = typeof(T);
            foreach ( var f in t.GetProperties())
            {
                var name = f.Name;
                var value = f.GetValue(dto);

                // TODO 他の型も対応するか
                if (value != null && (value is string))
                {
                    Claim claim = new Claim(name, (string)value);
                    claimList.Add(claim);
                };
            }

            //TODO cookieの有効期限

            var identity = new ClaimsIdentity(claimList, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            //認証cookieをレスポンスに追加
            await HttpContext.SignInAsync(principal);
        }

    }
}
