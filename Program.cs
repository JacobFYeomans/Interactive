using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program
    {
        static int pageNumber = 0;
        static string input;
        static bool acceptingInput = false;
        static void PlayerInput()
        {
            acceptingInput = true;
            while (acceptingInput == true)
            {
                input = Console.ReadLine();
                Console.WriteLine(input);
                break;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Interactive Story");

            PlayerInput();

            Console.ReadKey(true);
        }
    }
}
