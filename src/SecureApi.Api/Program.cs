using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de Health Checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configura o endpoint de Health Checks
// O predicate filtra para não mostrar tags específicas se necessário
// ResponseWriter formata a saída em um JSON legível por UIs
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapGet("/", () => "Secure API is running!");

app.Run();
