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

            if (string.IsNullOrEmpty(model.MonedaOrigen) || string.IsNullOrEmpty(model.MonedaDestino))
        {
            ModelState.AddModelError("", "Debe seleccionar una moneda de origen y destino.");
            return View(model);
        }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.MonedaOrigen == model.MonedaDestino)
            {
                ModelState.AddModelError(string.Empty, "Selecciona una moneda diferente para el cambio.");
                return View(model);
            }

            model.Resultado = ObtenerCambio(model.MonedaOrigen, model.MonedaDestino, model.Cantidad);
            return View(model);
        }

        public IActionResult GenerarBoleta(string Nombre, string Documento, string Correo, string MonedaOrigen, string MonedaDestino, decimal Cantidad, decimal Resultado, DateTime FechaNamcimiento)
    {
        var boleta = new BoletaViewModel
    {
        Nombre = Nombre,
        Documento = Documento,
        FechaNacimiento = FechaNamcimiento,
        Correo = Correo,
        MonedaOrigen = MonedaOrigen,
        MonedaDestino = MonedaDestino,
        Cantidad = Cantidad,
        Resultado = Resultado,
        Fecha = DateTime.Now
    };

    return View("Boleta", boleta);
}

        private decimal ObtenerCambio(string origen, string destino, decimal cantidad)
        {
            var tasas = new Dictionary<string, decimal>
            {
                { "USD_EUR", 0.91m }, { "USD_MXN", 17.2m }, { "USD_BRL", 5.1m }, { "USD_PEN", 3.8m },
                { "EUR_USD", 1.10m }, { "EUR_MXN", 18.9m }, { "EUR_BRL", 5.6m }, { "EUR_PEN", 4.2m },
                { "MXN_USD", 0.058m }, { "MXN_EUR", 0.053m }, { "MXN_BRL", 0.30m }, { "MXN_PEN", 0.22m },
                { "BRL_USD", 0.20m }, { "BRL_EUR", 0.18m }, { "BRL_MXN", 3.33m }, { "BRL_PEN", 0.75m },
                { "PEN_USD", 0.26m }, { "PEN_EUR", 0.24m }, { "PEN_MXN", 4.54m }, { "PEN_BRL", 1.33m }
            };

            string clave = $"{origen}_{destino}";
            return tasas.ContainsKey(clave) ? cantidad * tasas[clave] : 0;
        }
    }
}


