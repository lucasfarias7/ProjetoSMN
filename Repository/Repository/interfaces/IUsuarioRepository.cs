using Models.Models;
using SMNPastel.Models.Domain.Autenticacao;

namespace SMNPastel.Repository.interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> FindUserById(int subordinadoId);
        Task<Usuario?> GetUserByEmailAsync(LoginModel login);
        Task<IEnumerable<Usuario>> getUsers();
    }
}
