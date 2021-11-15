using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program
    {
        static bool gameRunning = false;
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
                acceptingInput = false;
                break;
            }
        }
        static void Menu() //does this need to be a separate method from PlayerInpiut();
        {
            gameRunning = true;
            while (gameRunning == true)
            {
                input = Console.ReadLine();
                if (input == "=") // pause/menu button is >>> = <<<
                {
                    Console.WriteLine("debug");
                }
            }
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
            
            Menu();
            //Page();
            //PlayerInput();

            Console.ReadKey(true);
        }
    }
}
