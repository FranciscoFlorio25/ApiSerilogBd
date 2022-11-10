using ApiSerilogBd.Api.Routes.ProductRoutes;
using Application;
using Infraestructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json",optional:false,reloadOnChange: true).Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

builder.Host.UseSerilog();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapProducts();


app.Run();
