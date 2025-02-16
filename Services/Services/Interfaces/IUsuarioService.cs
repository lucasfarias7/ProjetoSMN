using Models.Models;
using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> GetUserByEmailAsync(LoginModel login);
        Task<IEnumerable<Usuario>> getUsers();
    }
}
