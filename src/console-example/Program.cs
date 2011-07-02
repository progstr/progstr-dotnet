using System;
using Progstr.Log;

namespace ConsoleExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            LogSettings.ApiToken = "DEMO";
            Logs.Get<Program>().Info("Hello, from a console app");
            
            Console.ReadLine();
        }
    }
}

