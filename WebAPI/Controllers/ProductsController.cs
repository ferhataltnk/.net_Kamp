using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]  //İstek yapılırken clientların nasıl ulaşacağını belirtiyoruz. 
    [ApiController]  //Attribute -- Java'da annotation olarak geçiyor.Attribute bir class ile ilgili bilgi vermedir.Bu classın bir controller olduğunu .net'e belirtip kendini ona göre yapılandırması gerektiğini söylüyoruz.
    public class ProductsController : ControllerBase
    {
        //Controllerin IProductService bağımlısı ancak gevşek bağımlılık. (Loosely coupled)
        //naming convention 
        //Ioc Container -- Inersion Of control
        IProductService _productService; //Bağımlılık zinciri oluşmaması için dependency injection yapıyoruz.

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get() //Get ismini biz uydurduk.
        {
           // Dependency Chain --
           
            var result = _productService.GetAll();
            return result.Data;

        }
    }
}
