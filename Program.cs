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
        static void Menu()
        {

        }
        static void Page()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("PAGE: " + pageNumber);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("A Short Tale of Variable Adventures");
            Console.WriteLine("By: Jacob. F. Yeomans");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Page();
            PlayerInput();

            Console.ReadKey(true);
        }
    }
}
