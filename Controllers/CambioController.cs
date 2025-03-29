using CasaDeCambio.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeCambio.Controllers
{
    public class CambioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CambioMoneda());
        }

        [HttpPost]
        public IActionResult Index(CambioMoneda model)
        {
            if (model.MonedaOrigen == model.MonedaDestino)
            {
                ModelState.AddModelError(string.Empty, "Selecciona una moneda diferente para el cambio.");
                return View(model);
            }

            model.Resultado = ObtenerCambio(model.MonedaOrigen, model.MonedaDestino, model.Cantidad);
            return View(model);
        }

        private decimal ObtenerCambio(string origen, string destino, decimal cantidad)
        {
            var tasas = new Dictionary<string, decimal>
            {
                { "USD_EUR", 0.91m },
                { "USD_MXN", 17.2m },
                { "USD_BRL", 5.1m },  
                { "EUR_USD", 1.10m },
                { "EUR_MXN", 18.9m },
                { "EUR_BRL", 5.6m },  
                { "MXN_USD", 0.058m },
                { "MXN_EUR", 0.053m },
                { "MXN_BRL", 0.30m },  
                { "BRL_USD", 0.20m },  
                { "BRL_EUR", 0.18m },  
                { "BRL_MXN", 3.33m } 
            };

            string clave = $"{origen}_{destino}";
            return tasas.ContainsKey(clave) ? cantidad * tasas[clave] : 0;
        }
    }
}

