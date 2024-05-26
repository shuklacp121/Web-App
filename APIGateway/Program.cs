using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", p =>
    {
        p.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseCors("CorsPolicy");
app.UseOcelot().Wait();
app.MapControllers();
app.Run();
