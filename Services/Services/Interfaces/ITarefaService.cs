using SMNPastel.Models.Domain;
using SMNPastel.ViewModel;

namespace SMNPastel.Services.Interfaces
{
    public interface ITarefaService
    {
        Task Excluir(TarefaViewModel model);
        Task<TarefaViewModel> GetTarefaById(int id);
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task SaveOrUpdate(TarefaViewModel model);
    }
}
