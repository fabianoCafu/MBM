using AutoMapper;
using SelectionMBM.VagaAPI.DTO;
using SelectionMBM.VagaAPI.Repository.Interface;
using SelectionMBM.VagaAPI.Service.Interface;
using SelectionMBM.VagaAPI.ViewModel;

namespace SelectionMBM.VagaAPI.Service
{
    public class VagaService : IVagaService
    {
        private readonly IVagaRepository _repository;
        private readonly IMapper _mapper;

        public VagaService(
            IVagaRepository repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public bool Create(VagaViewModel model)
        {
            var vagaDTO = _mapper.Map<VagaDTO>(model);
            return _repository.Create(vagaDTO);
        }

        public bool Update(VagaViewModel model)
        {
            var vagaDTO = _mapper.Map<VagaDTO>(model);
            return _repository.Update(vagaDTO);
        }

        public bool Delete(string id)
        {
            return _repository.Delete(id);
        }

        public VagaViewModel FindById(string id)
        {
            var vagaDTO = _repository.FindById(id);
            return _mapper.Map<VagaViewModel>(vagaDTO);
        }

        public List<VagaViewModel> FindByTitle(string titleVaga)
        {
            var listaVagaDto = _repository.FindByTitle(titleVaga);
            return _mapper.Map<List<VagaViewModel>>(listaVagaDto);
        }

        public List<VagaViewModel> FindAll()
        {
            var listaVagaDto = _repository.FindAll();
            return _mapper.Map<List<VagaViewModel>>(listaVagaDto);
        }

        public List<CandidatosViewModel> FindByOpportunity(string id)
        {
            var listaCandidatosDto = _repository.FindByOpportunity(id);
            return _mapper.Map<List<CandidatosViewModel>>(listaCandidatosDto);
        }
    }
}
