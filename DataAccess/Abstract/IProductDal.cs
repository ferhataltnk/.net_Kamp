using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //İnterface'in operasyonları default olarak publictir.İnterfacein kendisini de katmanlı mimarilerde public yapıyoruz ki diğer katanlar da erişebilsin.
    public interface IProductDal : IEntityRepository<Product>  // Dal = Data Access Layer - Dao = Data Access Object
    {
        List<ProductDetailDto> GetProductDetails();

    }
}
