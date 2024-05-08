using Microsoft.EntityFrameworkCore;
using MinisuperZeus.BC.Constantes;
using MinisuperZeus.BW.CU;
using MinisuperZeus.BW.Interfaces.BW;
using MinisuperZeus.BW.Interfaces.DA;
using MinisuperZeus.DA.Acciones;
using MinisuperZeus.DA.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Conexion a BD
builder.Services.AddDbContext<MinisuperZeusContext>(options =>
{
    // Usar la cadena de conexi?n desde la configuraci?n
    options.UseSqlServer(ConnectionStringDb.ConnectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aqu?, si es necesario
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias
builder.Services.AddTransient<IGestionarProductoBW, GestionarProductoBW>();
builder.Services.AddTransient<IGestionarProductoDA, GestionarProductoDA>();
builder.Services.AddTransient<IGestionarListaDeDeseosBW, GestionarListaDeDeseosBW>();
builder.Services.AddTransient<IGestionarListaDeDeseosDA, GestionarListaDeDeseosDA>();

var app = builder.Build();

//configuracion de cors
app.UseCors("AllowOrigin");
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
