namespace CasaDeCambio.Models
{
    public class CambioMoneda
    {
        public string? MonedaOrigen { get; set; }
        public string? MonedaDestino { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Resultado { get; set; }
    }
}
