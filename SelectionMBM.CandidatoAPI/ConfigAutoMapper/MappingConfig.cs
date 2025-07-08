using AutoMapper;
using SelectionMBM.CandidatoAPI.DTO;
using SelectionMBM.CandidatoAPI.Model;
using SelectionMBM.CandidatoAPI.ViewModel;

namespace SelectionMBM.CandidatoAPI.ConfigAutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<CandidatoDTO, Candidato>().ReverseMap();
                config.CreateMap<CandidatoDTO, CandidatoViewModel>().ReverseMap();
            });
        }
    }
}
