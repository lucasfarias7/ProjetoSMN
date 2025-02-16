using Microsoft.EntityFrameworkCore;
using Models.Models;
using SMNPastel.Data;
using SMNPastel.Models.Domain.Autenticacao;
using SMNPastel.Repository.interfaces;

namespace SMNPastel.Repository.ClasseConcreta
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private SMNContext _context;

        public UsuarioRepository(SMNContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> getUsers() 
        {
            var result = await _context.Usuarios.AsNoTracking().AsQueryable().ToListAsync();
            return result;
        }

        public async Task<Usuario?> GetUserByEmailAsync(LoginModel login)
        {
            var result = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Email == login.EmailLogin);

            return result;
        }

        public async Task<Usuario> FindUserById(int subordinadoId)
        {
            var result = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == subordinadoId);

            return result;
        }
    }
}
