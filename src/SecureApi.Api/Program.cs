using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de Health Checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configura o endpoint de Health Checks
// O predicate filtra para n�o mostrar tags espec�ficas se necess�rio
// ResponseWriter formata a sa�da em um JSON leg�vel por UIs
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapGet("/", () => "Secure API is running!");

app.Run();
