
namespace SistemaBoletimTransporteDigital.Controllers
{
    internal class DadosViewModel
    {
        public int Id { get; set; }
        public DateTime DataInicioCorrida { get; set; }
        public DateTime? DataFinalCorrida { get; set; }
        public string DescricaoCorrida { get; set; }
        public int? KmInicial { get; set; }
        public int? KmFinal { get; set; }
        //public string Placa { get; set; }
        //public string Celular { get; set; }
        //public int Qtd { get; set; }
    }
}