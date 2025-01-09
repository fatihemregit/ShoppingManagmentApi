using Business.Utils.Extensions;
using Data.Utils.Extensions;
using Microsoft.AspNetCore.RateLimiting;
using ShoppingManagment.Utils.Extensions;
using ShoppingManagment.Utils.Middleware;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DataExtensions
builder.Services.ConfigureSqlContextForDataLayer(builder.Configuration);
builder.Services.setInterfaceConcretesForDataLayer();
builder.Services.setAutoMapperForDataLayer();
//ServiceExtensions
builder.Services.setAutoMapperForBusinessLayer();
builder.Services.setInterfaceConcretesForBusinessLayer();
//MainExtensions
builder.Services.setAutoMapperForMainLayer();
builder.Services.setRateLimiter(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseRateLimiter();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
