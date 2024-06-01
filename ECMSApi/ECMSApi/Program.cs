using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.BussinessLayer.Repository;
using ECMSApi.Service.BussinessLayer.Service;
using ECMSApi.Service.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ECMSContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//Dependancy Injection
builder.Services.AddTransient<DapperService>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<SQLConnectionString>();

builder.Services.AddScoped<ITest,TestRepository>();
builder.Services.AddScoped<IProducts,ProductRepository>();
builder.Services.AddScoped<ISizes,SizeRepository>();
builder.Services.AddScoped<ICategories, CategoryRepository>();
builder.Services.AddScoped<IInventoryLevels, InventoryLevelRepository>();
builder.Services.AddScoped<IColor,ColorRepository >();
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<IUserLogin, UserLoginRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors(x => x
			   .AllowAnyMethod()
			   .AllowAnyHeader()
			   .SetIsOriginAllowed(origin => true) // allow any origin
			   .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
