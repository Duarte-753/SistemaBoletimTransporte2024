namespace SistemaBoletimTransporteDigital.Models
{
    public class CorridaModel : VeiculoModel 
    {
        public int IdCorrida { get; set; }

        public DateTime DataInicioCorrida { get; set; } = DateTime.Now;

        public DateTime DataTerminoCorrida { get; set; } = DateTime.Now;

        public string DescricaoCorrida { get; set; }     

        public string NomeMotorista { get; set; }

        public List<VeiculoModel> ListaVeiculos { get; set; }

    }
}
