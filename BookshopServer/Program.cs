using BookshopServer.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);
const int Port = 5000;

// Keep this sample on a fixed plaintext HTTP/2 port for local tools and the companion articles.
// Use TLS and authentication before exposing a gRPC endpoint outside local development.
builder.WebHost.ConfigureKestrel(options =>
{
  options.ListenLocalhost(Port, o => o.Protocols =
      HttpProtocols.Http2);
});

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<InventoryService>();

// Enable reflection in Debug mode.
if (app.Environment.IsDevelopment())
{
  app.MapGrpcReflectionService();
}
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
