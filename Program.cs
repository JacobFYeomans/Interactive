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
        static string[] story = new string[4];
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
        static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to a variable tale. In the course of your journey, you will make many choices that will define your story.");
            Console.WriteLine("                    Now, make your first choice... will you start your adventure?");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Menu() //does this need to be a separate method from PlayerInput();
        {
            gameRunning = true;
            while (gameRunning == true)
            {
                input = Console.ReadLine();
                if (input == "=") // pause/menu button is >>> = <<<
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("        Pause Menu");
                    Console.WriteLine("To save game, enter 'S' key");
                    Console.WriteLine("To load game, enter 'L' key");
                    Console.WriteLine("To exit game, enter 'X' key");
                    Console.ForegroundColor = ConsoleColor.White;
                    input = Console.ReadLine();
                    if (input == "S")
                    {
                        //lmao this is going to be annoying
                    }
                    if (input == "L")
                    {
                       // ^^^^^^^^
                    }
                    if (input == "X")
                    {
                        Environment.Exit(0);
                    }
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
            Console.WriteLine("To access menu, enter '='");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Introduction();
            Menu();
            //Page();
            //PlayerInput();

            Console.ReadKey(true);
        }
    }
}
