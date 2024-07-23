using fronts.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace fronts.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient; // Cliente HTTP para hacer peticiones

        public UserController(IHttpClientFactory httpClientFactory)
        {
            // Constructor que inicializa el cliente HTTP
            _httpClient = httpClientFactory.CreateClient(); // Crea un cliente HTTP usando la factoría
            _httpClient.BaseAddress = new Uri("https://localhost:7045"); // Establece la URL base para las peticiones
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Username, string Password)
        {
            var requestUri = $"/Login?Username={Username}&Password={Password}";
            var response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<int>(content); // Suponiendo que la respuesta es un int
                switch (result)
                {
                    case 1:
                        return RedirectToAction("traerProductosAdmin");
                    case 2:
                        return RedirectToAction("traerProductosGestor");
                    case 0:
                        ModelState.AddModelError("", "Error: Usuario o contraseña incorrectos.");
                        return View(); // Devuelve la vista Index con un mensaje de error
                    default:
                        ModelState.AddModelError("", "Error inesperado.");
                        return View(); // Devuelve la vista Index con un mensaje de error

                }
            }
            else
            {
                // Si el login falla, redirige de vuelta a la vista Index
                return RedirectToAction("Index");

            }
        }

        public async Task<IActionResult> traerProductosAdmin()
        {

            var response = await _httpClient.GetAsync($"/traerProductosAdmin"); // Realiza una petición GET para obtener los detalles de un usuario por su ID

            if (response.IsSuccessStatusCode) // Si la petición es exitosa
            {
                var content = await response.Content.ReadAsStringAsync(); // Lee el contenido de la respuesta
                var Producto = JsonConvert.DeserializeObject<List<ProductoViewModel>>(content); // Convierte el JSON en una lista de ProductoViewModel

                // var usuario = JsonConvert.DeserializeObject<ProductoViewModel>(content); // Convierte el JSON en un objeto UsuariosViewmodels
                return View(Producto); // Muestra la vista con los detalles del usuario
            }
            else
            {
                // Si no se puede obtener el usuario, redirige a la vista "Index"
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> traerProductosGestor()
        {

            var response = await _httpClient.GetAsync($"/traerProductosGestor"); // Realiza una petición GET para obtener los detalles de un usuario por su ID

            if (response.IsSuccessStatusCode) // Si la petición es exitosa
            {
                var content = await response.Content.ReadAsStringAsync(); // Lee el contenido de la respuesta
                var Producto = JsonConvert.DeserializeObject<List<ProductoViewModel>>(content); // Convierte el JSON en una lista de ProductoViewModel

                // var usuario = JsonConvert.DeserializeObject<ProductoViewModel>(content); // Convierte el JSON en un objeto UsuariosViewmodels
                return View(Producto); // Muestra la vista con los detalles del usuario
            }
            else
            {
                // Si no se puede obtener el usuario, redirige a la vista "Index"
                return RedirectToAction("Index");
            }
        }

        public async Task<object> Edit(int ProductoId)
        {
            var response = await _httpClient.GetAsync($"/Edit?ProductoId={ProductoId}"); // Realiza una petición GET para obtener los detalles de un usuario por su ID

            var content = await response.Content.ReadAsStringAsync(); // Lee el contenido de la respuesta
            var EditarProducto = JsonConvert.DesrializeObject<object>(content); // Convierte el JSON en una lista de ProductoViewModel
            return EditarProducto;
        }



    }


}
