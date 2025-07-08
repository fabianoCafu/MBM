using SelectionMBM.CandidatoAPI.DTO;

namespace SelectionMBM.CandidatoAPI.Repository.Interface
{
    public interface ICandidatoRepository
    {
        bool Create(CandidatoDTO candidatoDTO);
        bool Update(CandidatoDTO candidatoDTO);
        bool Delete(string id);
        CandidatoDTO FindById(string id);
        List<CandidatoDTO> FindByName(string nomeCandidato);
        List<CandidatoDTO> FindAll();
    }
}
