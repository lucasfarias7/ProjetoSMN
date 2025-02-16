using AutoMapper;
using SMNPastel.Models.Domain;
using SMNPastel.Repository.interfaces;
using SMNPastel.Services.Interfaces;
using SMNPastel.ViewModel;

namespace SMNPastel.Services.ClasseConcreta
{
    public class TarefaService : ITarefaService
    {
        private readonly IMapper _mapper;
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository,
            IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            var result = await _tarefaRepository.GetTarefas();
            return result;
        }

        public async Task SaveOrUpdate(TarefaViewModel model)
        {
            var modelTarefa = _mapper.Map<Tarefa>(model);

            await _tarefaRepository.SaveOrUpdate(modelTarefa);
        }

        public async Task<TarefaViewModel> GetTarefaById(int id)
        {
            var result = await _tarefaRepository.GetTarefaById(id);
            return result;
        }

        public async Task Excluir(TarefaViewModel model)
        {
            var modelTarefa = _mapper.Map<Tarefa>(model);

            await _tarefaRepository.Excluir(modelTarefa);
        }
    }
}
