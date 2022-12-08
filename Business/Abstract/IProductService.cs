using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
       // List<Product> GetAll();
        IDataResult<List<Product>> GetAll();
      //  List<Product> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllByCategoryId(int id);


        //List<Product> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
      //  Product GetById(int productId);
        IDataResult<Product> GetById(int productId);
       
        //  void Add(Product product);
        IResult Add(Product product);  //void döndürenlerin sonucunu kullanıcıya iletebilmek için IResult kullanacağız artık.
        
        //RESTFUL --> HTTP (Bir kaynağa ulaşmak için izlediğimiz protokollerden birisidir.İnternet protokolüdür.ASP.Net controllerında da bize yapılabilecek istekleri kodluyoruz.Biz kendi controllerımızı oluşturacağız.  TCP protokol de var...) --> TCP (iki cihazı kablo ile birbiri ile görüştürmek için kullanılan protokol) 
    }
}
