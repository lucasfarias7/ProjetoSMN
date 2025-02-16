using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMNPastel.Data;
using SMNPastel.Models.Domain;
using SMNPastel.Repository.interfaces;
using SMNPastel.ViewModel;

namespace SMNPastel.Repository.ClasseConcreta
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IMapper _mapper;
        private readonly SMNContext _context;

        public TarefaRepository(SMNContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            var query = await _context.Tarefas
                .AsNoTracking()
                .Include(t => t.Subordinado)
                .AsQueryable()
                .ToListAsync();
            return query;
        }

        public async Task SaveOrUpdate(Tarefa model)
        {
            if (model.Id > 0)
                _context.Tarefas.Update(model);
            else
                await _context.Tarefas.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task<TarefaViewModel> GetTarefaById(int id)
        {
            var result = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<TarefaViewModel>(result);
        }

        public async Task Excluir(Tarefa model)
        {
            _context.Tarefas.Remove(model);
            await _context.SaveChangesAsync();            
        }
    }
}
