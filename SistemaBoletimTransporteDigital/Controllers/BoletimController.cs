using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.ViewModels;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class BoletimController : Controller
    {
        private readonly BancoContext _bancoContext;

        public BoletimController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<IActionResult> Index(BoletimViewModel model)
        {
            // Definir datas padrão caso não tenham sido fornecidas
            if (!model.Filtros.DataInicial.HasValue)
            {
                model.Filtros.DataInicial = DateTime.Now.AddMonths(-1);
            }

            if (!model.Filtros.DataFinal.HasValue)
            {
                model.Filtros.DataFinal = DateTime.Now;
            }

            // Realizar a consulta no banco de dados usando as datas fornecidas
            var corridas = await _bancoContext.Corridas
                .Where(c => c.DataInicioCorrida >= model.Filtros.DataInicial && c.DataFinalCorrida <= model.Filtros.DataFinal)
                .Select(c => new BoletimViewModel
                {
               
                }).ToListAsync();

           
                return View(corridas);
            
        }
    }
}
