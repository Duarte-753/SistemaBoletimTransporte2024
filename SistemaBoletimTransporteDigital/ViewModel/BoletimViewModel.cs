using SistemaBoletimTransporteDigital.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.ViewModels
{
    public class BoletimViewModel
    {
        public BoletimViewModel()
        {
            Filtros = new Filtro();
            Dados = new List<CorridaModel>();
        }
        public Filtro Filtros { get; set; }

        public List<CorridaModel> Dados { get; set; }


    }

    public class Filtro
    {
        [DataType(DataType.Date)]
        public DateTime? DataInicial { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFinal { get; set; }
    }

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
