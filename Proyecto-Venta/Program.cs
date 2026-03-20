using Proyecto_Venta.Interfaces;
using Proyecto_Venta.Data;
using Proyecto_Venta.Api;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<IExtractor, CsvExtractor>();
builder.Services.AddTransient<IExtractor, DatabaseExtractor>();
builder.Services.AddTransient<IExtractor, ApiExtractor>();

builder.Services.AddHttpClient<ApiExtractor>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
