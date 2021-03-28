using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarListed = "Araçlar listelendi";
        public static string DailyPriceInvalid = "Araç fiyatı geçersiz";

        public static string CarModelAdded = "Araba modeli eklendi";
        public static string CarModelUpdated = "Araba modeli güncellendi";
        public static string CarModelDeleted = "Araba modeli silindi";
        public static string ModelNameMustUnique = "Bu model zaten var";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandNameMustUnique = "Bu marka kaydı zaten var";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorNameMustUnique = "Bu renk kaydı zaten var";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";

        public static string RentalAdded = "Araç kiralandı";
        public static string RentalAddError = "Araç kiralanamadı";
        public static string RentalUpdated = "Kiralama bilgisi güncellendi";
        public static string RentalDeleted = "Kiralama bilgisi silindi";
        public static string CarNotDelivered = "Araç henüz teslim edilmedi";

        public static string CarImageAdded = "Araç fotoğrafı eklendi";
        public static string CarImageUpdated = "Araç fotoğrafı güncellendi";
        public static string CarImageDeleted = "Araç fotoğrafı silindi";
        public static string CarImageLimitExceeded="Fotoğraf sınırı aşıldı";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarIdMustUnique="Bir araç aynı anda birden fazla kişiye kiralanamaz";

        public static string ImageAdded = "Fotoğraf eklendi";
        public static string ImageUpdated = "Fotoğraf güncellendi";
        public static string ImageDeleted = "Fotoğraf silindi";

        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Hatalı şifre";
        public static string UserAlreadyExists="Kullanıcı zaten var";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string AuthorizationDenied="Yetkilendirme reddedildi";
		public static string FailedCarImageAdd="Fotoğraf yüklenirken hata oluştu";
		public static string ReturnedRental="Kiralama bilgisi döndürüldü";
		public static string FailedRentalAddOrUpdate="Bu kiralık araç daha önce eklenmiş";
		public static string AlreadyRented="Bu araç belirlediğiniz tarihlerde dolu , ileriki bir tarih seçiniz";
		public static string ErrorCarFindeksPoint= "Kiralanmak istenen aracın findeks puanı yok , başka bir araç seçin";
        public static string ErrorCustomerFindeksPoint = "Findeks puanınız olmadığından bu aracı size kiralayamayız";
		public static string InsufficientFindeksScore="Findeks puanınız bu aracı kiralamak için yetersiz";
        public static string CustomerNotFound = "Böyle bir müşteri bulunamadı";
        public static string CustomerNotUpdated = "Müşteri bilgilerini güncellerken bir hatayla karşılaştık";
        public static string UserNotUpdated = "Kullanıcı bilgilerini güncellerken bir hatayla karşılaştık";
	}
}
