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
            var services = new FB.Services.PlayerServices();

            try
            {
                Console.WindowWidth = 150;
                Console.WindowHeight = 20;

                if (args.Length > 0)
                {
                    switch (args[0].ToLower())
                    {
                        #region -GetTodaysTransactions

                        case "-gettodaystransactions":
                            services.Transactions.GetTransactions();
                            break;

                        #endregion

                        #region -GetMonthlyTransactions [Month]

                        case "-getmonthlytransactions":
                            if (args.Length < 2) throw new Exception("The 'Month' parameter (i.e. June) was not provided.");
                            string month = args[1];
                            services.Transactions.GetMonthlyTransactions(month);
                            break;

                        #endregion
                    }
                }

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
