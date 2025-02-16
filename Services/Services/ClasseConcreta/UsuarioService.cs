using Microsoft.EntityFrameworkCore;
using Models.Models;
using SMNPastel.Models.Domain.Autenticacao;
using SMNPastel.Providers;
using SMNPastel.Repository.interfaces;
using SMNPastel.Services.Interfaces;

namespace SMNPastel.Services.ClasseConcreta
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordProvider _passwordProvider;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPasswordProvider passwordProvider)
        {
            _usuarioRepository = usuarioRepository;
            _passwordProvider = passwordProvider;
        }

        public async Task<IEnumerable<Usuario>> getUsers()
        {
            var result = await _usuarioRepository.getUsers();

            return result;
        }

        public async Task<Usuario?> GetUserByEmailAsync(LoginModel login)
        {
            login.EmailLogin = login.EmailLogin.Trim();
            login.Senha = login.Senha.Trim();

            var usuario = await _usuarioRepository.GetUserByEmailAsync(login);

            if (usuario is null)
                return null;

            if (_passwordProvider.HashPassword(login.Senha, usuario.Salt) != usuario.Senha)
                return null;

            return usuario;
        }
    }
}
