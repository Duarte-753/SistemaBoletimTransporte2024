namespace SistemaBoletimTransporteDigital.Models
{
    public class CorridaModel 
    {
        public int Id { get; set; }

        public DateTime DataInicioCorrida { get; set; } = DateTime.Now;

        public DateTime DataFinalCorrida { get; set; } = DateTime.Now;

        public string? DescricaoCorrida { get; set; }

        public int UsuarioID { get; set; }

        public UsuarioModel? Usuario { get; set; }

        public int VeiculoID { get; set; }

        public VeiculoModel? Veiculo { get; set; }
    }
}
