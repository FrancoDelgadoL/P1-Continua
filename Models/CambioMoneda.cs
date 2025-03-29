namespace CasaDeCambio.Models
{
    public class CambioMoneda
    {
        public string MonedaOrigen { get; set; } = string.Empty;
        public string MonedaDestino { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public decimal Resultado { get; set; }
    }
}
