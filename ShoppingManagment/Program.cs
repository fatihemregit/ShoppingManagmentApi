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
builder.Services.AddRateLimiter(options =>
{
	//bu istek sayýlarýný daha sonra güncelleyelim(mobile app kýsmýný yazdýktan sonra ihtiyaca göre belirleylim)
	int ratelimitMultiple = int.Parse(builder.Configuration.GetSection("RatelimitMultiple").Value);

	

	options.AddFixedWindowLimiter("productController", options =>
	{
		options.AutoReplenishment = true;
		options.PermitLimit = ratelimitMultiple * 3;
		options.Window = TimeSpan.FromMinutes(1);
	});
	options.AddFixedWindowLimiter("marketController", options =>
	{
		options.AutoReplenishment = true;
		options.PermitLimit = ratelimitMultiple * 2;
		options.Window = TimeSpan.FromMinutes(1);
	});

	options.AddFixedWindowLimiter("orderController", options =>
	{
		options.AutoReplenishment = true;
		options.PermitLimit =  ratelimitMultiple * 1;
		options.Window = TimeSpan.FromMinutes(1);
	});
	//global limit
	//options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
	//	RateLimitPartition.GetFixedWindowLimiter(
	//		partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
	//		factory: partition => new FixedWindowRateLimiterOptions
	//		{
	//			AutoReplenishment = true,
	//			PermitLimit = ratelimitMultiple * 1,
	//			Window = TimeSpan.FromMinutes(1)
	//		}));

	options.OnRejected = async (context, token) =>
	{
		context.HttpContext.Response.StatusCode = 429;
		await context.HttpContext.Response.WriteAsync("çok fazla istekte bulundunuz 1 dakika sonra tekrar deneyiniz", cancellationToken: token);
	};
});
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
