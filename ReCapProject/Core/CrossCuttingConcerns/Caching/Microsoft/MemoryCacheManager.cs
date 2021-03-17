using Core.Utilities.IOC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
	public class MemoryCacheManager : ICacheManager
	{
		//Adapter Pattern
		IMemoryCache _memoryCache;

		public MemoryCacheManager()
		{
			_memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
		}

		public void Add(string key, object value, int duration)
		{
			_memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
		}

		public T Get<T>(string key)
		{
			return _memoryCache.Get<T>(key);
		}

		public object Get(string key)
		{
			return _memoryCache.Get(key);
		}

		public bool IsAdd(string key)
		{
			return _memoryCache.TryGetValue(key, out _);
		}

		public void Remove(string key)
		{
			_memoryCache.Remove(key);
		}

		public void RemoveByPattern(string pattern)//Reflatcion yardımıyla çalışma anında Cache'den silme işlemi yapıyoruz verilen pattern'e göre
		{
			var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);//.Net kendi belleğinde yani Cache'inde veriyi EntriesCollection kısmında tutuyor bizde GetProperty metodu yardımıyla bunu buluyoruz 
			var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;//Bizim kendi Cache'imizi buluyoruz
			List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

			foreach (var cacheItem in cacheEntriesCollection)//.Net'in her bir Cache elemanını geziyoruz 
			{
				ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
				cacheCollectionValues.Add(cacheItemValue);
			}

			var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);//Parametre olarak verdiğimiz pattern kuralını burada oluşturuyoruz alt satırda kullanıcaz
			var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();//.Net'in her bir Cache elemanından bu satırdaki regex ile tanımlı kurallara uyanları buluyor ve keysToRemove içine atıyoruz

			foreach (var key in keysToRemove)//keysToRemove içinde parametre olarak verdiğimiz pattern kurallarına uyan Cache elemanları var ve bunları tek tek siliyoruz foreach ile
			{
				_memoryCache.Remove(key);
			}
		}
	}
}
