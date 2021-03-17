using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)//Datamız bozulduğu zaman çalışan bir fonksiyondur , Data yeni data eklenirse , güncellenirse veya silinirse Cache'deki data bozulur işte o zaman Cache'deki eski data silinmesi için bu metod kullanılır
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)//OnSuccess olmasının sebebi misal Add,Delete veya Update metodu çalıştırıldı ve belki hata verdi ve işlem yapılamadı yani veri değişmedi o zaman Cache'deki verinin karşılığını silmemize gerek kalmaz ancak Add,update,delete fonksiyonları çalışırsa yani OnSuccess olursa yani başarılı şekilde çalıştıktan sonra Cache'deki verileri siliyoruz
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
