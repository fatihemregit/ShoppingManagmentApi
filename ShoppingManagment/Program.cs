using Business.Utils.Extensions;
using Data.Utils.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DataExtensions
builder.Services.ConfigureSqlContextForDataLayer(builder.Configuration);
builder.Services.setAutoMapperForDataLayer();
//ServiceExtensions
builder.Services.setAutoMapperForBusinessLayer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
