using CoderCarrer.DAL;
using CoderCarrer.Domain;
using CoderCarrer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CoderCarrer.Controllers
{
   
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            IExtratorVaga vagasDao = new TrabalhaBrasilDAO();
            IExtratorVaga vagascomDao = new VagaComDAO();
            IExtratorVaga vagasTrovit = new VagasTrovit();
           // IExtratorVaga vagasTrampo = new TrampoDAO();

            List<Vaga> vagas = vagasDao.getVagas();
            List<Vaga> vagascom = vagascomDao.getVagas();
            List<Vaga> vagastrovit = vagasTrovit.getVagas();
          //  List<Vaga> vagastrampo = vagasTrampo.getVagas();

            List<Vaga> vaga = new List<Vaga>();
            vaga.AddRange(vagas);
            vaga.AddRange(vagascom);
            vaga.AddRange(vagastrovit);
          //  vaga.AddRange(vagastrampo);



            return View(vaga);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


       
       
    }
}