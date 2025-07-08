using Microsoft.AspNetCore.Mvc;
using SelectionMBM.Web.Models;
using SelectionMBM.Web.Service.IService;

namespace SelectionMBM.Web.Controllers
{
    public class VagaController : Controller
    {
        private readonly ILogger<VagaController> _logger;
        private readonly IVagaService _vagaService;

        public VagaController(
            ILogger<VagaController> logger,
            IVagaService vagaService)
        {
            _vagaService = vagaService ?? throw new ArgumentNullException(nameof(vagaService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> DeleteVaga(Guid id)
        {
            var respeonse = await _vagaService.DeleteVagaById(id);

            if (respeonse is not null)
            {
                return RedirectToAction(nameof(IndexVaga));
            }

            return View();
        }

        public async Task<IActionResult> IndexVaga(string? tituloVaga = null)
        {
            var model = new List<VagaViewModel>();

            if (string.IsNullOrWhiteSpace(tituloVaga))
            {
                model = await _vagaService.FindAllVagas();
            }
            else
            {
                model = await _vagaService.FindVagaByTitle(tituloVaga);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateVaga()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVaga(VagaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vagaService.CreateVaga(model);

                if (response is not null)
                {
                    return RedirectToAction(nameof(IndexVaga));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditVaga(Guid id)
        {
            var response = await _vagaService.FindVagaById(id);

            if (response is not null)
            {
                return View(response);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditVaga(VagaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vagaService.UpdateVaga(model);

                if (response is not null)
                {
                    return RedirectToAction(nameof(IndexVaga));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsVaga(Guid id)
        {
            var response = await _vagaService.FindVagaById(id);

            if (response is not null)
            {
                return View(response);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CandidatosVaga(Guid id)
        {
            var model = new List<CandidaturaViewModel>();

            var response = await _vagaService.FindAllCandidatos(id);

            if (response is not null)
            {
                return View(response);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CandidaturaVaga()
        {
            var model = await _vagaService.FindAllVagas();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CandidaturaVaga(CandidaturaViewModel candidatura)
        {
            return View();
        }
    }
}
