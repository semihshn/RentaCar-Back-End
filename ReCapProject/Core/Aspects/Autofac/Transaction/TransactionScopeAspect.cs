using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();//Transaction uygulanan metod =invocation ve proceed fonksiyonu ile metodu çalıştırıyoruz ama Try-catch bloğu içinde çalıştırıyoruz
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();//Hedef metodumuz hata verdiği zaman 
                    throw;
                }
            }
        }
    }
}
