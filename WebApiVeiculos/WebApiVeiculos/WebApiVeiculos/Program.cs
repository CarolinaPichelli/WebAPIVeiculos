using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura o Serilog antes de criar o builder
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext() // Boa pr�tica: adicionar contexto
    .CreateLogger();

try
{
    Log.Information("Iniciando a aplica��o...");

    // Aplica o Serilog ao Host
    builder.Host.UseSerilog();

    // Adiciona os servi�os ao container
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Registra o IVeiculoService e sua implementa��o VeiculoService
    builder.Services.AddScoped<IVeiculoService, VeiculoService>();

    // Configura o DbContext com a string de conex�o
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
        )
    );

    var app = builder.Build();

    // Configura��o do pipeline HTTP
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "A aplica��o falhou ao iniciar.");
}
finally
{
    Log.CloseAndFlush();
}
