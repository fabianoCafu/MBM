using SelectionMBM.Web.Models;

namespace SelectionMBM.Web.Service.IService
{
    public interface ICandidatoService
    {
        Task<CandidatoViewModel> CreateCandidato(CandidatoViewModel model);
        Task<CandidatoViewModel> UpdateCandidato(CandidatoViewModel model);
        Task<CandidatoViewModel> DeleteCandidatoById(Guid id);
        Task<List<CandidatoViewModel>> FindAllCandidatos();
        Task<CandidatoViewModel> FindCandidatoById(Guid id);
        Task<List<CandidatoViewModel>> FindCandidatoByName(string nomeCandidato); 
    }
}
