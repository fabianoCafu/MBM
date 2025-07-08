using AutoMapper;
using SelectionMBM.CandidatoAPI.DTO;
using SelectionMBM.CandidatoAPI.Repository.Interface;
using SelectionMBM.CandidatoAPI.Service.Interface;
using SelectionMBM.CandidatoAPI.ViewModel;

namespace SelectionMBM.CandidatoAPI.Service
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _repository;
        private readonly IMapper _mapper;

        public CandidatoService(
            ICandidatoRepository repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public bool Create(CandidatoViewModel model)
        {
            var candidatoDTO = _mapper.Map<CandidatoDTO>(model);
            return _repository.Create(candidatoDTO);
        }

        public bool Update(CandidatoViewModel model)
        {
            var candidatoDTO = _mapper.Map<CandidatoDTO>(model);
            return _repository.Update(candidatoDTO);
        }

        public bool Delete(string id)
        {
            return _repository.Delete(id);
        }

        public CandidatoViewModel FindById(string id)
        {
            var candidatoDTO = _repository.FindById(id);  
            return _mapper.Map<CandidatoViewModel>(candidatoDTO);
        }

        public List<CandidatoViewModel> FindByName(string nomeCandidato)
        {
            var listtaCandidatoDto = _repository.FindByName(nomeCandidato);
            return _mapper.Map<List<CandidatoViewModel>>(listtaCandidatoDto);
        }

        public List<CandidatoViewModel> FindAll()
        {
            var listtaCandidatoDto = _repository.FindAll();
            return _mapper.Map<List<CandidatoViewModel>>(listtaCandidatoDto); 
        }
    }
}
