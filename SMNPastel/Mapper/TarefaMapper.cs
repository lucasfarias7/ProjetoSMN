using AutoMapper;
using SMNPastel.Models.Domain;
using SMNPastel.ViewModel;

namespace SMNPastel.Mapper
{
    public class TarefaMapper : Profile
    {
        public TarefaMapper()
        {
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
        }
    }
}
