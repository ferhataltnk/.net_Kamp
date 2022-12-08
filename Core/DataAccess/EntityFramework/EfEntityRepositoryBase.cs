using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>  // Bir tablo bir de çalışacağım context tipi istiyorum.<T,T> gibi bir şey yani.   Daha sonra bu class IEntityRepository interfacesini imlemente ediyor.Ederken de kendisi oluşturulurken istediği TEntity'yi yine interface'in istediği parametre olarak gönderiyor.
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        //NorthwindContext gördüğüm yerlere TContext, Product gördüğüm yerlere de TEntity yazarak Generic hale getirdim.
        //ORM: Veritabanı nesneleri ile kodlar arasında ilişki kurup veri tabanı işlerini yapma süreci.C#'ta linq ile yapıyoruz.    
        public void Add(TEntity entity)
        {
            //IDispossable Pattern implementation of C# -- altta kullanılan using ile kütüphane dahil etmek için kullanılan using aynı şey değildir.
            using (TContext context = new TContext  ())  //using fonksiyonu tamamlandığı anda burada kullanılan nesne fonksiyon tamamlanır tamamlanmaz bellekten garbage collector sayesinde temizlenir.Çünkü contetxt nesnesi çok performans harcar.
            {
                var addedEntity = context.Entry(entity);  //entity yani veritabanı nesnesinin referansını yakalıyoruz.
                addedEntity.State = EntityState.Added;   //referans üzerinden tablo kontrol edilir eklenmemişse eklenir.    
                context.SaveChanges(); //işlemleri gerçekleştir komutudur.Zaten bir tane ekleme işlemimiz olduğundan ekleme işlemi gerçekleştirilir.
            }
        }

        public void Delete(TEntity entity)
        {

            using (TContext context = new TContext())  //using bloğu tamamlanınca newlenen context nesnesi kaldırılıyor.
            {
                var deletedEntity = context.Entry(entity);  //Gelen nesnenin referansını deletedEntity nesnesine atıyorum.
                deletedEntity.State = EntityState.Deleted;    //Silme işlemi burada gerçekleşiyor.  
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)  // category ve customer tabloları için de aynı işlemi product yerine o tablonun ismini yazarak uygulayabiliriz.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)  // filter= null --> default olarak filtre kısmı boş olduğundan filtre verebilir de vermeyebilir de.
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();// filtre gelmediyse veritabanındaki product tablosunu listeye çevir ve gönder.Filtre geldiyse Where (filter ) kısmında filtreyi uygula veritabanından gelen product tablosunu contexte set edip listeye çevir ve gönder.Where(filter) kısmı p => p.product gibi lambda sorgularını fonksiyonu çağırırkenn yapabilmemizi sağlıypr.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
