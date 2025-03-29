
namespace CasaDeCambio.Models
{
    public class BoletaViewModel
    {
        public string Nombre { get; set; } = "";
        public string Documento { get; set; } = "";
        public string Correo { get; set; } = "";
        public string MonedaOrigen { get; set; } = "";
        public string MonedaDestino { get; set; } = "";
        public decimal Cantidad { get; set; }
        public decimal Resultado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaNacimiento { get; set; }
         
    }
}
