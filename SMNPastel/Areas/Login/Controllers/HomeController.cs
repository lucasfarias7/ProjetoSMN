using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SMNPastel.Services.Interfaces;
using SMNPastel.Models.Domain.Autenticacao;
using Models.Models;

namespace SMNPastel.Areas.Login.Controllers
{
    [Area("Login")]
    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: HomeController        
        public IActionResult Login(string? returnurl = null)
        {
            var login = new LoginModel();
            return View(login);
        }

        // POST: HomeController/LoginPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(login);

                return await LoginUsuario(login);
            }
            catch
            {
                return View(login);
            }
        }

        private async Task<IActionResult> LoginUsuario(LoginModel login)
        {
            var usuario = await _usuarioService.GetUserByEmailAsync(login);

            if (usuario is null)
                return BadRequest(new { Mensagem = "Usuário não encontrado, ou e-mail ou senha inválida, tente novamente ou entre em contato com o suporte." });

            if (usuario.PrimeiroAcesso.GetValueOrDefault())
                return RedirectToAction("RedefinirSenha", "Home", new { Area = "Login", usuarioId = usuario.Id });

            await CreateCookieUserAsync(usuario);

            return RedirectToAction("Index", "Home", new { Area = "" });

        }

        private async Task CreateCookieUserAsync(Usuario usuario)
        {
            List<Claim> userClaims = CreateUserClaims(usuario);

            var identity = new ClaimsIdentity(userClaims, "User");
            var userPrincipal = new ClaimsPrincipal(new[] { identity });

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1)
                }
            );
        }

        private List<Claim> CreateUserClaims(Usuario usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            return claims;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
