using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Net.Http.Headers;

namespace ConsoleUI
{
    //sOlid
    //O: Open Close Principle  --> Yaptığın yazılıma yeni bir özellik ekliyorsan mevcut olan kodlara dokunmaman gerekecek şekilde tasarlamalısın.

     class Program  
    {
        static void Main(string[] args)
        {
            //DTO = Data Transformation Object
            ProductTest();

           // CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static ProductManager ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+ " / " + product.CategoryName);
            }

            return productManager;
        }
    }
}