using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // burada liste oluşturmamızın sebebi sanki bu verileri veritabanından çekiyomuuz gibi simule etmemiz.
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);   // business katmanından buraya gönderilen ürünü ekliyorum
        }

        public void Delete(Product product)
        {
            /////////////////////////////////////////////////////


            //Product productToDelete = null; // burada new Producut(); şeklinde atama yaparsak referans adresi vermiş oluruz ve daha sonra bulduğumuz nesneyi buna atasak da adres farklı olacağından yine de silemeyiz.    
            //foreach (var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);


            /////////////////////////////////////////////////////////////////////
            //    _products.Remove(product);   // Normalde listeden eleman bu şekilde silinebiliyor ancak.Bu şekilde yaparsak asla silemeyiz.Çünkü arayüzden oluşturulup gönderilen nesne aynı olsa bile referansı farklı olacaktır.int,string gibi değer tippleri olsa silebilirdik ancak bu ekilde referans numarasıyla tutulan değişkenleri silemeyiz.Gelen nesne sayesinde asıl nesnenin referansına ulaşıp onu silmeliyiz.Normalde tek tek listeyi döngüyle dolaşıpp gönderilen nesnenin id'siyle aynı olan nesneyi bulup listeden silmem gerekirdi ancak Link sayesinde kolay bir şekilde halledebiliyoru


            //LINQ = Language Integrated Query
            // Linq SingleOrDefault() listeyi tek tek bizim için dolaşıyor.
            // =>  --> lambda

            
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId==product.ProductId);  // buradaki p alias olarak kullanılıyor.Bu fonksiyon sonucunda pparametre içindeki koşulu sağlayan değerin referansını döndürüyor.
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList(); //Where koşulu içindeki şarta uyan bütün elemanları getirir.ToList() diyerek de list yappıyoruz.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)  //Buradaki product UI'dan gelecek.
        {
            //Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId==product.ProductId);  // buradaki p alias olarak kullanılıyor.Bu fonksiyon sonucunda pparametre içindeki koşulu sağlayan değerin referansını döndürüyor.
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitsInStock;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
