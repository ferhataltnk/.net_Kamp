using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductDetailDto : IDto  //IEntity'yi implemente edemem çünkü bir veritabanı tablosu değil.Burada joinli tablo işlemleri yapacağız.
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
