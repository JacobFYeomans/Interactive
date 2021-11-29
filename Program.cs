using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program //string.contains can be used to find keywords within strings to create win and lose states
    {
        static int pageNumber = 0; //current page, displayed value is +1 to prevent a page 0 from existing.
        static int maxPage = 19; //for range checking purposes
        static string input;
        static string[] story = File.ReadAllLines(@"story.txt");
        static bool firstChoice = true;
        static int choice;
        static string[] pageContents;
        static bool failState = false; //the game runs on a while loop that requires this to be false

        static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to a variable tale. In the course of your journey, you will make many choices that will define your story.");
            Console.WriteLine("                    Now, make your first choice... will you start your adventure?");
            Console.WriteLine("                                 Press '1' to Start, or '2' to quit");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        } 
        static void PrintIntroInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                        ┌─┐  ┌─┐┬ ┬┌─┐┬─┐┌┬┐  ┌┬┐┌─┐┬  ┌─┐");
            Console.WriteLine("                                        ├─┤  └─┐├─┤│ │├┬┘ │    │ ├─┤│  ├┤ ");
            Console.WriteLine("                                        ┴ ┴  └─┘┴ ┴└─┘┴└─ ┴    ┴ ┴ ┴┴─┘└─┘");
            Console.WriteLine("                                         ┌─┐┌─┐  ┬  ┬┌─┐┬─┐┬┌─┐┌┐ ┬  ┌─┐");
            Console.WriteLine("                                         │ │├┤   └┐┌┘├─┤├┬┘│├─┤├┴┐│  ├┤ ");
            Console.WriteLine("                                         └─┘└     └┘ ┴ ┴┴└─┴┴ ┴└─┘┴─┘└─┘");
            Console.WriteLine("                                         ┌─┐┌┬┐┬  ┬┌─┐┌┐┌┌┬┐┬ ┬┬─┐┌─┐┌─┐");
            Console.WriteLine("                                         ├─┤ ││└┐┌┘├┤ │││ │ │ │├┬┘├┤ └─┐");
            Console.WriteLine("                                         ┴ ┴─┴┘ └┘ └─┘┘└┘ ┴ └─┘┴└─└─┘└─┘");
            Console.WriteLine("By: Jacob. F. Yeomans");
            //Console.WriteLine("To access menu, enter '='");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void PrintPage(int page) //calls the actual story
        {
            if (page != -1 && firstChoice == false) //needs to be able to access Story[0]
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("PAGE: " + (page + 1)); // done so that there is no page 0
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (string x in pageContents)
                {
                    if (x != null && x != pageContents[3] && x != pageContents[4]) //anti-modular, extra credit to fix end page is not 5 segments, will not print properly
                    {
                        Console.WriteLine(x); //consider printing options in a different colour
                        Console.WriteLine();
                    }

                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }  
        static void StringSplitter() //Must be called before first choice.
        {
            pageContents = story[pageNumber].Split(';'); 
        }
        static void DefineChoice(int page)
        {
            choice = int.Parse(pageContents[page]); // need to do something about this, game over text doesn't display properly.
            pageNumber = choice - 1; //just so pages display properly
        } //Console.Beep(tone, length); for sound effects
        static void PlayerChoice() //perhaps decouple StringSplitter from PlayerChoice
        {
            input = Console.ReadLine();
            switch (input)
            {
                case "1":

                    if (firstChoice == false)
                    {
                        DefineChoice(3); //Anti-Modular
                    }
                    if (firstChoice == true)
                    {
                        firstChoice = false;
                    }
                    break;

                case "2":

                    if (firstChoice == true)
                    {
                        Environment.Exit(0);
                    }
                    if (firstChoice == false)
                    {
                        DefineChoice(4); //Anti-Modular
                    }
                    break;

                default:
                    
                    if (firstChoice == true)
                    {
                        Console.WriteLine("Input not recognized, please chose option 1 to start or 2 to quit."); // skips first page if improper input on Start/Quit
                        PlayerChoice();
                    }
                    if (firstChoice == false)
                    {
                        Console.WriteLine("Input not recognized, please chose option 1 or 2");
                        PlayerChoice();
                    }
                    break;

            }
        } //to chose start/quit on game load, will eventually include load from save.
        static void EndGame()
        {
            if (pageContents[0].Contains("magnitudes"))
            {
                Console.WriteLine("      ┬─┐┌─┐┌─┐┌┬┐  ┌┬┐┬ ┬┌─┐  ┌─┐┌┬┐┌─┐┬─┐┬ ┬  ┌─┐┌─┐┌─┐┬┌┐┌  ┌─┐┌─┐┬─┐  ┌─┐  ┌┐┌┌─┐┬ ┬  ┌─┐┬ ┬┌┬┐┌─┐┌─┐┌┬┐┌─┐┬");
                Console.WriteLine("      ├┬┘├┤ ├─┤ ││   │ ├─┤├┤   └─┐ │ │ │├┬┘└┬┘  ├─┤│ ┬├─┤││││  ├┤ │ │├┬┘  ├─┤  │││├┤ │││  │ ││ │ │ │  │ ││││├┤ │");
                Console.WriteLine("      ┴└─└─┘┴ ┴─┴┘   ┴ ┴ ┴└─┘  └─┘ ┴ └─┘┴└─ ┴   ┴ ┴└─┘┴ ┴┴┘└┘  └  └─┘┴└─  ┴ ┴  ┘└┘└─┘└┴┘  └─┘└─┘ ┴ └─┘└─┘┴ ┴└─┘o");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            if (pageContents[0].Contains("vain"))
            {
                Console.WriteLine("                                   ┬ ┬┌─┐┬ ┬┬─┐   ┬┌─┐┬ ┬┬─┐┌┐┌┌─┐┬ ┬  ┬┌─┐  ┌─┐┬  ┬┌─┐┬─┐");
                Console.WriteLine("                                   └┬┘│ ││ │├┬┘   ││ ││ │├┬┘│││├┤ └┬┘  │└─┐  │ │└┐┌┘├┤ ├┬┘");
                Console.WriteLine("                                    ┴ └─┘└─┘┴└─  └┘└─┘└─┘┴└─┘└┘└─┘ ┴   ┴└─┘  └─┘ └┘ └─┘┴└─");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
        }
        static void Main(string[] args)
        {
            PrintIntroInfo();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            StringSplitter();
            Introduction();
            while (failState == false) //gameplay loop
            {
                while (pageNumber - 1 < maxPage) //loop is double nested to allow range checking on the page//consider splitting loop into 2 if statements so that story doesn't skip first page if improper input is detected in first choice.
                {
                    StringSplitter();
                    PrintPage(pageNumber);
                    StringSplitter();
                    EndGame(); //checks to see if the story is over
                    PlayerChoice(); //find a way to split story[0] before first choice is made.
                }
            } //gameplay loop

            Console.ReadKey(true);
        }
    }
}
