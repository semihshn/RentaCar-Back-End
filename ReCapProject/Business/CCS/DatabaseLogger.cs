using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Add()
        {
            Console.WriteLine("Veritabanı loglandı");
        }
    }
}
