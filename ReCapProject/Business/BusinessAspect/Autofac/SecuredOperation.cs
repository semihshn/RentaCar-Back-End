using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspect.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//Rolleri Atrribute ile verirken birden çok rol hedef metodu kullansın istiyorsak aralarına virgül koyabilmemizi sağlıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//Business/DependencyResolvers/Autofac/AutofacBusinessModule'de yaptığımız instance oluşturma işlemini burda da yapıyoruz ki Authorization işlemleri tüm platformlarda çalıştın ; Desktop , web , Mobil vs..
        }

        protected override void OnBefore(IInvocation invocation)//Authorization işlemi method çalışamdan önce çalışsın diye OnBefore metodu ovveride ediliyor
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//o anki kullancıının rolleri bulunuyor 
            foreach (var role in _roles)//Bu kullanıcın rollerini gez claimlerinin içinde ilgili rol varsa return et yani ilgili metodu çalıştır ama eğer yetkisi yoksa yetkin yok hatası ver de..
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            return;
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
