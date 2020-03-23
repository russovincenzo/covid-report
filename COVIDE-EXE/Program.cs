using System;
using System.Linq;

namespace COVID_19
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputkey = "";
            do
            {
                Console.WriteLine("Scegli regione");
                inputkey = Console.ReadLine();
                if (inputkey.Contains("ita"))
                {
                    foreach (var row in new LoadJson().GetDataFromWebNaz())
                    {
                        Console.WriteLine(row.ToString());

                    }
                }else
                foreach (var row in new LoadJson().GetDataFromWebRegione().Where(x => x.Regione.Contains(inputkey)))
                {
                    Console.WriteLine(row.ToString());

                }
                Console.WriteLine();
            } while (inputkey != "q");

            
        }
    }
}
