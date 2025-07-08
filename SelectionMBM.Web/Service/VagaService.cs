using SelectionMBM.Web.Models;
using SelectionMBM.Web.Service.IService;
using SelectionMBM.Web.Util;

namespace SelectionMBM.Web.Service
{
    public class VagaService : IVagaService
    {
        private readonly HttpClient _client;
        public const string BasePathVaga = "api/v1/vaga";
        public const string BasePathCandidato = "api/v1/candidato";

        public VagaService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<VagaViewModel> CreateVaga(VagaViewModel model)
        {
            var response = await _client.PostAsJson($"{BasePathVaga}/create", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<VagaViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<VagaViewModel> UpdateVaga(VagaViewModel model)
        {
            var response = await _client.PutAsJson($"{BasePathVaga}/update", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<VagaViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<VagaViewModel> DeleteVagaById(Guid id)
        {
            var response = await _client.DeleteAsync($"{BasePathVaga}/delete/{id}/");

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<VagaViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<List<VagaViewModel>> FindAllVagas()
        {
            var response = await _client.GetAsync($"{BasePathVaga}/get/findall/");
            return await response.ReadContentAs<List<VagaViewModel>>();
        }

        public async Task<VagaViewModel> FindVagaById(Guid id)
        {
            var response = await _client.GetAsync($"{BasePathVaga}/get/by-id/{id}");
            return await response.ReadContentAs<VagaViewModel>();
        }

        public async Task<List<VagaViewModel>> FindVagaByTitle(string nomeCandidato)
        {
            var response = await _client.GetAsync($"{BasePathVaga}/get/by-title/{nomeCandidato}/");
            return await response.ReadContentAs<List<VagaViewModel>>();
        }

        public async Task<List<CandidaturaViewModel>> FindAllCandidatos(Guid id)
        {
            var response = await _client.GetAsync($"{BasePathVaga}/get/by-opportunity/{id}/");
            return await response.ReadContentAs<List<CandidaturaViewModel>>();
        }

        public async Task<List<CandidatoViewModel>> FindAllCandidato(string email)
        {
            var response = await _client.GetAsync($"{BasePathCandidato}/get/by-email/{email}/");
            return await response.ReadContentAs<List<CandidatoViewModel>>();
        }
    }
}
