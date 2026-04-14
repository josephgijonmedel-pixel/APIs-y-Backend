var builder = WebApplication.CreateBuilder(args);

// 1. Agregamos el servicio de Controladores (VITAL para que reconozca tu AlertasController)
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 2. Mapeamos los controladores para que las rutas como /api/alertas funcionen
app.MapControllers();

app.Run();