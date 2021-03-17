using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;//Bu metod ne kadar sürede çalışacak onu ölçmek için bir değişken

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)//Metodu başlatmadan önce kronometreyi başlatıyor
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)//Metodun çalışma süresi _interval'dan büyükse 
            {//interval=interval değerini bussines katmanında attribute olarak PerformanceAspect verdiğimizde parametre olarak veriyoruz bu sayede diyoruz ki metoda metodun çalışma süresi ... dan fazla ise beni uyar o kodda iyileştirmeye gideyim 
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
