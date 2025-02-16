using SMNPastel.Models.Domain;
using SMNPastel.ViewModel;

namespace SMNPastel.Repository.interfaces
{
    public interface ITarefaRepository
    {
        Task Excluir(Tarefa model);
        Task<TarefaViewModel> GetTarefaById(int id);
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task SaveOrUpdate(Tarefa model);
    }
}
