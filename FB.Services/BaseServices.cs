using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FB.Services
{
    internal static class ConsoleLogger
    {
        internal static void Log(string logDesc)
        {
            Console.WriteLine("{0:yyyyMMdd hhmmss}: {1}", DateTime.Now, logDesc);
        }
    }

    public class PlayerServices
    {
        public PlayerServices()
        {
            //TODO: a web.config field should tell us which services to load

            this.Transactions = new FB.Services.Yahoo.TransactionServices();
        }

        public ITransactionServices Transactions { get; set; }
    }

    public interface ITransactionServices
    {
        void GetTransactions();
    }
}
