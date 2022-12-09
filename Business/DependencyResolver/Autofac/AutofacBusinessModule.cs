using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder) //Flutter Binding gibi bir şey.Uygulama çalıştığında çalışacak kısım.
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();  //Birisi senden IProductService isterse ona ProductManager instance'ı ver. 
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
