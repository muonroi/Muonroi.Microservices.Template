WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Add Service Discovery
// builder.Services.AddServiceDiscovery(builder.Configuration, builder.Environment);

WebApplication app = builder.Build();

app.MapReverseProxy();
app.MapGet("/", () => "Muonroi Microservices Gateway");

app.Run();
