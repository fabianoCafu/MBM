using SelectionMBM.Web.Models;
using SelectionMBM.Web.Service.IService;
using SelectionMBM.Web.Util;

namespace SelectionMBM.Web.Service
{
    public class CandidatoService : ICandidatoService
    {
        private readonly HttpClient _client;
        public const string BasePathCandidato = "api/v1/candidato";

        public CandidatoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<CandidatoViewModel>> FindAllCandidatos()
        {
            var response = await _client.GetAsync($"{BasePathCandidato}/get/findall/");
            return await response.ReadContentAs<List<CandidatoViewModel>>(); 
        }

        public async Task<CandidatoViewModel> FindCandidatoById(Guid id)
        {
            var response = await _client.GetAsync($"{BasePathCandidato}/get/by-id/{id}");
            return await response.ReadContentAs<CandidatoViewModel>();
        }

        public async Task<CandidatoViewModel> CreateCandidato(CandidatoViewModel model)
        {
            var response = await _client.PostAsJson($"{BasePathCandidato}/create", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CandidatoViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<CandidatoViewModel> UpdateCandidato(CandidatoViewModel model)
        {
            var response = await _client.PutAsJson($"{BasePathCandidato}/update", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CandidatoViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<CandidatoViewModel> DeleteCandidatoById(Guid id)
        {
            var response = await _client.DeleteAsync($"{BasePathCandidato}/delete/{id}/");

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CandidatoViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<List<CandidatoViewModel>> FindCandidatoByName(string nomeCandidato)
        {
            var response = await _client.GetAsync($"{BasePathCandidato}/get/by-name/{nomeCandidato}/");
            return await response.ReadContentAs<List<CandidatoViewModel>>();
        }
    }
}
