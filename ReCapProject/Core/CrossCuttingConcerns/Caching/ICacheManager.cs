using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
		T Get<T>(string key);

		object Get(string key);

		void Add(string key, object value, int duration);//key=Cachle'lenecek verinin id'si gibi düşünülebilir , value=Cache'lenecek değer , duration=Cache'de verinin durma süresi , misal 5sn verilirse veri Cache'lendikten 5sn sonra Cache'den silinir

		bool IsAdd(string key);//Cache'de var mı yok mu kontrolü yapıyor

		void Remove(string key);//Cache içerisindeki bir veriyi silmek istediğimizde kullanırız

		void RemoveByPattern(string pattern);//İçinde get olanlar , içinde category olanlar , içinde product olanlar gibi bir pattern verildiğinde içerisinde parametre olarak verdiğimiz pattern geçenleri Cache'den siler
	}
}
