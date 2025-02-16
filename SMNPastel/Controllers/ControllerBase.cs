using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMNPastel.Models.Domain.Autenticacao;
using SMNPastel.Repository.interfaces;

namespace SMNPastel.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected IEnumerable<Usuario>? _usuarios;
        private readonly IUsuarioRepository _usuarioRepository;

        protected ControllerBase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        private async Task LoadUsuariosAsync()
        {
            _usuarios = await _usuarioRepository.getUsers();
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await LoadUsuariosAsync();            
            await next();
        }
    }
}
