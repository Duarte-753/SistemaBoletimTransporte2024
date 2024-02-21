using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class PDFController : Controller
    {
        public IActionResult PDF_Teste()
        {
            return new ViewAsPdf("PDF_Teste") { FileName = ".pdf"};
        }
    }
}
