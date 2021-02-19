using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);//context=parametre olarak verdiğimiz entity clasımız yani veri tabanımızdaki tablo
            var result = validator.Validate(context);//Contexti Validate et , parametre olarak verdiğimiz , kendi oluşturduğumuz validasyosyon sınıfımıza göre ; CarValidator , BrandValidator vs.. hepsi Business/ValidationRules/FluentValidation içerisinde.
            if (!result.IsValid)//ValidationRules yani doğrulama kurallarına uyuyorsa IsValid True , uymuyorsa false değer alacak
            {
                throw new ValidationException(result.Errors);//Hangi doğrulama kuralına uymuyorsa onun hatasını göster
            }
        }
    }
}
