using SelectionMBM.CandidatoAPI.ViewModel;

namespace SelectionMBM.CandidatoAPI.Service.Interface
{
    public interface ICandidatoService
    {
        bool Create(CandidatoViewModel model);
        bool Update(CandidatoViewModel model);
        bool Delete(string id);
        CandidatoViewModel FindById(string id);
        List<CandidatoViewModel> FindAll();
        List<CandidatoViewModel> FindByName(string nomeCandidato);
    }
}
