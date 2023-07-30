using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Profiles
{
    public class InformacaoNutricionalProfile : Profile
    {
        public InformacaoNutricionalProfile()
        {
            CreateMap<InformacaoNutricionalViewModel, InformacaoNutricional>()
                .ForMember(x => x.PercentualValorDiario, opt => opt.MapFrom(x => x.PercentualValorDiario / 100));
        }
    }
}
