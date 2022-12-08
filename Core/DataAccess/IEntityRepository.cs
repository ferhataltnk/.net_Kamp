using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//Core katmanını biz oluşturduk.  .Net Core ile ilgisi yok. Core katmanı diğer katmanları referans almaz.Alırsa o katmamna bağımlı olduğumuz anlamına gelir.
namespace Core.DataAccess
{
    //Generic constraint  -- Jenerik kısıt
    //class: referans tip olabilir
    //IEntity: IEntity olabilir ya da IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı -- Yani parametre olarak IEntity gönderemez ancak IEntity'yi implemente eden classların nnesnelerini gönderebilir.
    public interface IEntityRepository<T> where T: class,IEntity,new()   // where T: --> T ne olabilir demek istiyorum aslında
    {   
        List<T> GetAll(Expression<Func<T,bool>> filter=null);   // Her sorgu için tek tek method yazma sorununu Expression ile gideriyoruz.
        T Get(Expression<Func<T, bool>> filter);   // Her şeyi değil de belirli bir filtre ile döndürmeyi sağlıyor.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
     //   List<T> GetAllByCategory(int categoryId);
    }
}
