using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class UsuarioReportController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnv;
        private readonly IRelatorioUsuarioRepositorio _usuarioRepositorio;

        public UsuarioReportController(IRelatorioUsuarioRepositorio relatorioUsuarioRepositorio, IWebHostEnvironment webHostEnvironment)// construtor do controlador
        {
            _usuarioRepositorio = relatorioUsuarioRepositorio;
            _webHostEnv = webHostEnvironment;
        }

        [Route("RelatorioUsuarioRepositorio")]
        public ActionResult RelatorioUsuarioRepositorio()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "FichaUsuarioPDF.frx"));

            var usuarios = HelperFastReport.GetTable(_usuarioRepositorio.BuscarUsuario(), "RelatorioUsuarioRepositorio");

            webReport.Report.RegisterData(usuarios, "RelatorioUsuarioRepositorio");

            return View(webReport);
        }

        [Route("RelatorioUsuarioRepositorioPDF")]
        public IActionResult RelatorioUsuarioRepositorioPDF()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"report\FichaUsuarioPDF.frx");//local do template para usar 
            var reportFile = caminhoReport;

            var freport = new FastReport.Report();
            var usuarioList = _usuarioRepositorio.BuscarUsuario();//carrega conforma o layout

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(usuarioList, "Lista de Usuário", 10, true);

            freport.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/zip","Lista_dos_Usuarios.pdf"); //retorna em pdf
        }

        public IActionResult UsuarioReport()
        {
            return View();
        }
    }
}
