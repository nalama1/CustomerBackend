using MSCliente.Data;
using MSCliente.Dominio.Interfaces;
using MSCliente.Services;

var builder = WebApplication.CreateBuilder(args);

//Configuración de CORS policy:
builder.Services.AddCors(options =>
{
    options.AddPolicy("AccesoClienteLocal", policy =>
    {
        policy.WithOrigins("https://localhost:44371")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//Agregando servicios al contenedor:
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de dependencia:
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

//Logging configuration:
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AccesoClienteLocal");
app.UseAuthorization();
app.MapControllers();


app.Run();