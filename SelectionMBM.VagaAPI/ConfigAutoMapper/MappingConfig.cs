using AutoMapper;
using SelectionMBM.VagaAPI.DTO;
using SelectionMBM.VagaAPI.Model;
using SelectionMBM.VagaAPI.ViewModel;

namespace SelectionMBM.VagaAPI.ConfigAutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<VagaDTO, Vaga>().ReverseMap();
                config.CreateMap<VagaDTO, VagaViewModel>().ReverseMap();
                config.CreateMap<CandidatosDTO, CandidatosViewModel>().ReverseMap();
                config.CreateMap<CandidatosDTO, Candidato>().ReverseMap();
            });
        }
    }
}
