using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolver.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

//Servis sa�lay�c� fabrikas� olarak (IOC) asp.net altyap�c� yerine Autofac yard�m�yla olu�turdu�um AutofacBusinessModule'�m� kullan!
//Autofac yerine ba�ka bir IOC altyap�s� kullanmak istersem AutofacServiceProviderFactory() ve AutofacBusinessModule() k�sm�n� de�i�tirip Business katman�nda DependencyResolver klas�r�ne yeni altyap�y� olu�turup onu bu k�sma getirmem yeterli.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder=> builder.RegisterModule(new AutofacBusinessModule()));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal,EfProductDal>();


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
