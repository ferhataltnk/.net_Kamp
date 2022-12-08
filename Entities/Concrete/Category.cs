using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:IEntity
    {  //Çıplak class kalmasın. IEntity'yi implement ettiği için Category classının bir veritabanı tablosu olduğunu anlayabiiryoruz.
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
