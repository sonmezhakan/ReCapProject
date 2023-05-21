using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ICarsService, CarsManager>();
builder.Services.AddSingleton<ICarsDal, EfCarDal>();
builder.Services.AddSingleton<IBrandsService,BrandsManager>();
builder.Services.AddSingleton<IBrandsDal,EfBrandDal>();
builder.Services.AddSingleton<IColorsService,ColorsManager>();
builder.Services.AddSingleton<IColorsDal,EfColorDal>();
builder.Services.AddSingleton<ICustomersService, CustomersManager>();
builder.Services.AddSingleton<ICustomersDal,EfCustomerDal>();
builder.Services.AddSingleton<IUsersService,UsersManager>();
builder.Services.AddSingleton<IUsersDal, EfUserDal>();
builder.Services.AddSingleton<IRentalsService,RentalsManager>();
builder.Services.AddSingleton<IRentalsDal,EfRentalDal>();
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
