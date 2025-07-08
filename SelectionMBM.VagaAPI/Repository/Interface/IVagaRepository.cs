using SelectionMBM.VagaAPI.DTO;

namespace SelectionMBM.VagaAPI.Repository.Interface
{
    public interface IVagaRepository
    {
        bool Create(VagaDTO vagaDTO);
        bool Update(VagaDTO vagaDTO);
        bool Delete(string id);
        VagaDTO FindById(string id);
        List<VagaDTO> FindByTitle(string titleVaga);
        List<VagaDTO> FindAll();
        List<CandidatosDTO> FindByOpportunity(string id);
    }
}
