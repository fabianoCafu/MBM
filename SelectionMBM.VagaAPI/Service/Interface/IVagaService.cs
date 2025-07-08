using SelectionMBM.VagaAPI.ViewModel;

namespace SelectionMBM.VagaAPI.Service.Interface
{
    public interface IVagaService
    {
        bool Create(VagaViewModel model);
        bool Update(VagaViewModel model);
        bool Delete(string id);
        VagaViewModel FindById(string id);
        List<VagaViewModel> FindAll();
        List<VagaViewModel> FindByTitle(string titleVaga);
        List<CandidatosViewModel> FindByOpportunity(string id);

    }
}
