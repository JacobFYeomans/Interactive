using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program
    {
        static int pageNumber = 1;
        static string input;
        static bool acceptingInput = false;
        static string[] story = new string[10];
        //static void PlayerInput()
        //{
           // acceptingInput = true;
            //input = Console.ReadLine();
            //while (acceptingInput == true)
            //{
                //if (input == "=") // pause/menu button is >>> = <<<
                //{
                    //Console.ForegroundColor = ConsoleColor.Blue;
                    //Console.WriteLine("        Pause Menu");
                    //Console.WriteLine("To save game, enter 'S' key");
                    //Console.WriteLine("To load game, enter 'L' key");
                    //Console.WriteLine("To exit game, enter 'X' key");
                    //Console.ForegroundColor = ConsoleColor.White;
                    //input = Console.ReadLine();
                    //if (input == "S")
                    //{
                        ////lmao this is going to be annoying
                        //acceptingInput = false;
                        //break;
                    //}
                    //if (input == "L")
                    //{
                        //// ^^^^^^^^
                        //acceptingInput = false;
                        //break;
                    //}
                    //if (input == "X")
                    //{
                        //Environment.Exit(0);
                    //}
                //}
                //if (input == "Q")
                //{
                    //Page(pageNumber);
                    //acceptingInput = false;
                    //break;
                //}
                //acceptingInput = false;
                //break;
            //}
        //}
        static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to a variable tale. In the course of your journey, you will make many choices that will define your story.");
            Console.WriteLine("                    Now, make your first choice... will you start your adventure?");
            Console.WriteLine("                                 Press '1' to Start, or '2' to quit");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Page(int page)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("PAGE: " + page);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(story[page - 1]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        static void Choice()
        {
            Console.WriteLine("Make a choice 1, 2, 3, or 4");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":

                    Page(pageNumber);
                    break;

                case "2":

                    Environment.Exit(0);
                    break;

                case "3":

                    break;

                case "4":

                    break;

                default:

                    Console.WriteLine("Input not recognized, please chose option 1-4");
                    break;
                    Choice();
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("A Short Tale of Variable Adventures");
            Console.WriteLine("By: Jacob. F. Yeomans");
            Console.WriteLine("To access menu, enter '='");
            Console.ForegroundColor = ConsoleColor.White;
            story[0] = "There once was a man from nantucket";
            story[1] = "Who said he lived in a bucket";
            story[2] = "he had two left shoes";
            story[3] = "an addiction to booze";
            story[4] = "and a burning hole in his pocket";
            story[5] = "";
            story[6] = "";
            story[7] = "";
            story[8] = "";
            story[9] = "";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Introduction();
            Choice();

            Console.ReadKey(true);
        }
    }
}
