using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelectionMBM.Web.Models;
using SelectionMBM.Web.Service.IService;

namespace SelectionMBM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVagaService _service;

        public HomeController(
            ILogger<HomeController> logger,
            IVagaService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "MBM Oportunidades"; 

            return View();
        }
    }
}