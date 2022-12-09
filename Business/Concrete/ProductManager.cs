using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Bir iş sınıfıf başka sınıflardan nesne üretmemeli !!! new'lemez yani.Injection yapılmalıdır.

        IProductDal _productDal;   // injection yapıyoruz.Soldaki gibi oluşturup constructor çağırmamız gerekiyor.

        public ProductManager(IProductDal productDal)  // dataAccess katmanının soyut kısmı ile erişime geçeceğiz sadece.Business katmanının tek bildiği şey IProductDal nesnesi.Entity Framework ya da InMemory bilmiyor.
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
          

            ValidationTool.Validate(new ProductValidator(),product);
         

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);  //Resultın içeriğini set etmedik ancak geçici olarak böyle return ediyoruz.Result bir IResult implementasyonu olduğu için onu kullandık.
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları
            //Kosullar sağlanıyor mu?
            //Yetkisi var mı ?

            //return _productDal.GetAll();

            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Başarılı");
        }

        public IDataResult< List<Product>> GetAllByCategoryId(int id)
        {
            //   return _productDal.GetAll(p => p.CategoryId == id);   //EfProductDal'daki GetAll() fonksiyonunun filtre işlemi olduğundaki versiyonunu çağırıp sonucunda gelen listeyi return ediyorum.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id),"Verilen idye göre kategoriler getirildi.");
        }

        public IDataResult<Product> GetById(int productId)
        {
            //return _productDal.Get(p=> p.ProductId==productId);
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            // return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),"İlgili aralığa göre ürünler getirildi");
           
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //return _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),"ürünler getirildi");
        }
    }
}
