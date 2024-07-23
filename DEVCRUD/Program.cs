using DEVCRUD.Clases;
using DEVCRUD.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var cn = new DAO_Dios();

app.MapGet("login", (string Username, string Password) =>    // Mapea una solicitud GET a la ruta 'traerProductos' que no espera ning�n par�metro.
{
    return cn.Login(Username, Password);    // Llama al m�todo traerProductos de la instancia cn (DAO_practica) para obtener todos los productos.
});

app.MapGet("traerProductosAdmin", () =>    // Mapea una solicitud GET a la ruta 'traerProductos' que no espera ning�n par�metro.
{
    return cn.traerProductosAdmin();    // Llama al m�todo traerProductos de la instancia cn (DAO_practica) para obtener todos los productos.
});

app.MapGet("traerProductosGestor", () =>    // Mapea una solicitud GET a la ruta 'traerProductos' que no espera ning�n par�metro.
{
    return cn.traerProductosGestor();    // Llama al m�todo traerProductos de la instancia cn (DAO_practica) para obtener todos los productos.
});

app.MapGet("Edit", (int ProductoId) =>    // Mapea una solicitud POST a la ruta 'guardarProductos' que espera un objeto de tipo Usuario como dato.
{
    return cn.Edit(ProductoId);    // Llama al m�todo Guardar de la instancia cn (DAO_practica) para guardar el objeto Usuario recibido.
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
