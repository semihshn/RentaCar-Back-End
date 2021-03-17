using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //Validasyon Attribute'umuzu oluşturduk ve parametre olarak hangi valdiasyon sınıfını verirsek o validasyonu uygulayacak method içine , yani business katmanı validasyonu buradan alıyor burasıda MethodInterceptor'dan alıyor bilgileri
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Activator.CreateInstance bir reflaction'dır yani bu satır çalışma anında Validasyonumuzun instance'ını yani örneğini oluşturuyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Validator'ın çalışma tipi bulunuyor ve bulunan çalışma tipinin generic type'ını buluyor. Generic Tipler=Cars,Brands,Users vs.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//Business katmanında hangi metod üzerinde Validasyon kullanıldıysa o metodun parametrelerini bulmayı sağlıyor
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//Bulunan parametreler tek tek geziliyor ve hepsi validasyon kurallarına uygun mu bakılıyor , kurallar ValidationTool'dan çekiliyor
            }
        }
    }
}
