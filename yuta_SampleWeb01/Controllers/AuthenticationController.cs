using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace yuta_SampleWeb01.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string loginId, string password)
        {

            if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
                return View("Index");
            }

            string role = loginId == "admin" ? "Administrator" : "General";



            var claims = new[] {
                new Claim(ClaimTypes.Name, loginId),
                new Claim(ClaimTypes.Role, role),// ユーザID
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            //認証cookieをレスポンスに追加
            await HttpContext.SignInAsync(principal);

            // 認証されたらHomeページへリダイレクトする
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // 認証Cookieをレスポンスから削除
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // ログイン画面にリダイレクト
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
