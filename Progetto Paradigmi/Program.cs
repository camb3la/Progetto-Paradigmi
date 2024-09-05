using Progetto_Paradigmi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);



var app = builder.Build();



// Configure the HTTP request pipeline.

app.AddWebMiddleware();

app.Run();