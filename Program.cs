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
        static string[] story = new string[10];
        static void PlayerInput()
        {
            acceptingInput = true;
            input = Console.ReadLine();
            while (acceptingInput == true)
            {
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
                        PlayerInput();
                    }
                    if (input == "L")
                    {
                        // ^^^^^^^^
                        PlayerInput();
                    }
                    if (input == "X")
                    {
                        Environment.Exit(0);
                    }
                }
                else //temporary stopgap measure
                {
                    PlayerInput();

                }
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
            story[0] = "";
            story[1] = "";
            story[2] = "";
            story[3] = "";
            story[4] = "";
            story[5] = "";
            story[6] = "";
            story[7] = "";
            story[8] = "";
            story[9] = "";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Introduction();
            PlayerInput();

            Console.ReadKey(true);
        }
    }
}
