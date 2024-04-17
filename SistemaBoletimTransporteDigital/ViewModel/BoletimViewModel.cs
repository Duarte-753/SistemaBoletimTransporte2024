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
}
