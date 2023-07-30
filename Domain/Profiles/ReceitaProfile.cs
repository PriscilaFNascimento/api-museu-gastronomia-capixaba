using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Profiles
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile()
        {
            CreateMap<Receita, ReceitaViewModel>()
                .ForMember(x => x.NomeCriador, opt => opt.MapFrom(src => src.Criador.Nome))
                .ForMember(x => x.NomeEditor, opt => opt.MapFrom(src => src.UltimoEditor.Nome));

            CreateMap<InserirReceitaViewModel, Receita>()
                .ForMember(x => x.InformacoesNutricionais, opt => opt.Ignore());
        }
    }
}
