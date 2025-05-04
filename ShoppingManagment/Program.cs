using Business.Utils.Extensions;
using Data.Utils.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
//using NLog.Extensions.Logging;
//using NLog;
using ShoppingManagment.Utils.Extensions;
using ShoppingManagment.Utils.Middleware;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DataExtensions
//builder.Services.ConfigureSqlContextForDataLayerSqlServer(builder.Configuration);
builder.Services.ConfigureSqlContextForDataLayerPostgre(builder.Configuration);
builder.Services.setInterfaceConcretesForDataLayer();
builder.Services.setAutoMapperForDataLayer();
//ServiceExtensions
builder.Services.setAutoMapperForBusinessLayer();
builder.Services.setInterfaceConcretesForBusinessLayer();
//MainExtensions
builder.Services.setAutoMapperForMainLayer();
builder.Services.setRateLimiter(builder.Configuration);
builder.Services.setAuthentication(builder.Configuration);
builder.Services.AddCors();
//// NLog yapýlandýrmasýný yükle
//var logger = LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();
//builder.Logging.ClearProviders();
//builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
//builder.Logging.AddNLog();


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRateLimiter();
app.MapGet("/", () => $"Yükleme baþarýlý\n{app.Environment.EnvironmentName}");
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
