using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FB_PlayerTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WindowWidth = 150;
                Console.WindowHeight = 20;

                var services = new FB.Services.PlayerServices();
                var d = DateTime.Now.AddDays(-6 * 30);
                //var players = services.Transactions.GetTransactions(d);

                services.Transactions.GetMonthlyTransactions("april");

                Console.WriteLine("Done.");
                Console.Read();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.Read();
            }
        }
    }
}
