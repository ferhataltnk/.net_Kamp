using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolver.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

//Servis saðlayýcý fabrikasý olarak (IOC) asp.net altyapýcý yerine Autofac yardýmýyla oluþturduðum AutofacBusinessModule'ümü kullan!
//Autofac yerine baþka bir IOC altyapýsý kullanmak istersem AutofacServiceProviderFactory() ve AutofacBusinessModule() kýsmýný deðiþtirip Business katmanýnda DependencyResolver klasörüne yeni altyapýyý oluþturup onu bu kýsma getirmem yeterli.
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
