using FrondCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FrondCrud.Controllers
{
    public class ProductoController : Controller
    {

        private readonly HttpClient _httpClient; // Cliente HTTP para hacer peticiones

        public ProductoController(IHttpClientFactory httpClientFactory)
        {
            // Constructor que inicializa el cliente HTTP
            _httpClient = httpClientFactory.CreateClient(); // Crea un cliente HTTP usando la factoría
            _httpClient.BaseAddress = new Uri("https://localhost:7066"); // Establece la URL base para las peticiones
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            // Serializar el modelo a JSON
            var json = JsonConvert.SerializeObject(userViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la solicitud POST a la API
            var response = await _httpClient.PostAsync("/login", content);

            if (response.IsSuccessStatusCode)
            {
                // Manejar la respuesta si es exitosa
                var responseBody = await response.Content.ReadAsStringAsync();
                // Puedes agregar lógica para manejar la respuesta aquí

                return RedirectToAction("Success"); // Redirige a otra acción o vista según sea necesario
            }
            else
            {
                // Manejar el error si la respuesta no es exitosa
                ModelState.AddModelError("", "No se pudo iniciar sesión. Verifica tus credenciales.");
                return View(userViewModel);
            }
        }

    }
}
