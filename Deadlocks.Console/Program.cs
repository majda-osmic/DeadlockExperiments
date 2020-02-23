using Deadlocks.DAL;
using System;
using System.Threading.Tasks;

namespace Deadlocks.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dal = new AsyncDataAccessWrapper();

            while (true)
            {
                System.Console.Write("Give me a number or \"exit\": ");
                var num = System.Console.ReadLine();
                switch (num)
                {
                    case "1": await dal.GetDataAsync_V1(); Ok(); break;
                    case "2": await dal.GetDataAsync_V2(); Ok(); break;
                    case "3": await dal.GetDataAsync_V3(); Ok(); break;
                    case "4": await dal.GetDataAsync_V4(); Ok(); break;
                    case "exit": return;
                    default: TryAgain(); break;
                }
            }
        }

        static void Ok()
        {
            System.Console.WriteLine("OK");
        }

        static void TryAgain()
        {
            System.Console.WriteLine("Try again!");
        }
    }
}
