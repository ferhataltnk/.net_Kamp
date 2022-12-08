using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {// Kategori ile ilgili dış dünyaya ne servis etmek istersem o operasyonları bu kısımda yazıyorum.  
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
    }
}
