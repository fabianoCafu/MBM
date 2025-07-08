using SelectionMBM.Web.Models;

namespace SelectionMBM.Web.Service.IService
{
    public interface IVagaService
    {
        Task<VagaViewModel> CreateVaga(VagaViewModel model);
        Task<VagaViewModel> UpdateVaga(VagaViewModel model);
        Task<VagaViewModel> DeleteVagaById(Guid id);
        Task<List<VagaViewModel>> FindAllVagas();
        Task<VagaViewModel> FindVagaById(Guid id);
        Task<List<CandidaturaViewModel>> FindAllCandidatos(Guid id);
        Task<List<VagaViewModel>> FindVagaByTitle(string titleVaga);
    }
}
