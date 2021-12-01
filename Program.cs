using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program //make text appear slowly
    {
        static int pageNumber = 0; //current page, displayed value is +1 to prevent a page 0 from existing.
        static int maxPage = 19; //for range checking purposes, find a way to parse the number of lines read from story.txt
        static string input;
        static string[] story = File.ReadAllLines(@"story.txt"); //parse # of lines read, make maxPages = # of lines read.
        static bool firstChoice = true;
        static int choice;
        static string[] pageContents;
        static bool failState = false; //the game runs on a while loop that requires this to be false

        static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(""); 
            Console.WriteLine("");
            Console.WriteLine("                                         Press '1' to Start");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                         Press '2' to quit");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                         Press '3' to load");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        } 
        static void PrintIntroInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                  ┌─┐  ┌─┐┬ ┬┌─┐┬─┐┌┬┐  ┌┬┐┌─┐┬  ┌─┐");
            Console.WriteLine("                                  ├─┤  └─┐├─┤│ │├┬┘ │    │ ├─┤│  ├┤ ");
            Console.WriteLine("                                  ┴ ┴  └─┘┴ ┴└─┘┴└─ ┴    ┴ ┴ ┴┴─┘└─┘");
            Console.WriteLine("                                   ┌─┐┌─┐  ┬  ┬┌─┐┬─┐┬┌─┐┌┐ ┬  ┌─┐");
            Console.WriteLine("                                   │ │├┤   └┐┌┘├─┤├┬┘│├─┤├┴┐│  ├┤ ");
            Console.WriteLine("                                   └─┘└     └┘ ┴ ┴┴└─┴┴ ┴└─┘┴─┘└─┘");
            Console.WriteLine("                                   ┌─┐┌┬┐┬  ┬┌─┐┌┐┌┌┬┐┬ ┬┬─┐┌─┐┌─┐");
            Console.WriteLine("                                   ├─┤ ││└┐┌┘├┤ │││ │ │ │├┬┘├┤ └─┐");
            Console.WriteLine("                                   ┴ ┴─┴┘ └┘ └─┘┘└┘ ┴ └─┘┴└─└─┘└─┘");
            Console.WriteLine("By: Jacob. F. Yeomans");
            //Console.WriteLine("To access menu, enter '='");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void PrintMainMenu() //merge intro and intro info?
        {

        }
        static void saveFileCheck()//to be used
        {

        }

        static void ColourText()
        {
            Console.ForegroundColor = ConsoleColor.Red;

        }
        static void PrintPage(int page)
        {
            if (page != -1 && firstChoice == false) 
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("PAGE: " + (page + 1)); // done so that there is no page 0
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (string x in pageContents)
                {
                    if (x != null && x != pageContents[3] && x != pageContents[4]) // X != null is to prevent an issue in which x can be null, x != pageContents[3] & [4] is to prevent the last 2 segments of the text from being printed
                    {
                            Console.WriteLine(x);
                            Console.WriteLine();
                    }

                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }  
        static void SplitString() //Must be called before first choice.
        {
            pageContents = story[pageNumber].Split(';'); 
        }
        static void ClearScreen() 
        {
            Console.Clear();
        }
        static void DefineChoice(int page)
        {
            choice = int.Parse(pageContents[page]);
            pageNumber = choice - 1; //this is where the page skip comes in
        } //Console.Beep(tone, length); for sound effects
        static void PlayerChoice() //add 3 and 4 for save and quit
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
                        DefineChoice(4); 
                    }
                    break;

                case "3":

                    if (firstChoice == false)
                    {
                        SaveGame();
                    }
                    if (firstChoice == true)
                    {
                        LoadGame();
                    }
                    break;

                default:
                    
                    if (firstChoice == true)
                    {
                        Console.WriteLine("Input not recognized, please chose option 1 to start or 2 to quit."); // skips first page if improper input on Start/Quit OR if you try to load game
                        PlayerChoice();
                    }
                    if (firstChoice == false)
                    {
                        Console.WriteLine("Input not recognized, please chose option 1 or 2");
                        PlayerChoice();
                    }
                    break;

            }
        }
        static void SaveGame()
        {
            string savePageNumber = pageNumber.ToString();
            File.WriteAllText(@"save.txt", savePageNumber);
            Console.WriteLine("File Saved.");
            PlayerChoice();
        }
        static void LoadGame()
        {
            string savePage = File.ReadAllText(@"save.txt");
            pageNumber = int.Parse(savePage); //range check for null
            firstChoice = false;
        }
        static void EndGame()
        {
            if (story[maxPage - 1].Contains(pageContents[0])) //if (pageContents[0].Contains("Ending"))
            {
                Console.WriteLine("      ┬─┐┌─┐┌─┐┌┬┐  ┌┬┐┬ ┬┌─┐  ┌─┐┌┬┐┌─┐┬─┐┬ ┬  ┌─┐┌─┐┌─┐┬┌┐┌  ┌─┐┌─┐┬─┐  ┌─┐  ┌┐┌┌─┐┬ ┬  ┌─┐┬ ┬┌┬┐┌─┐┌─┐┌┬┐┌─┐┬");
                Console.WriteLine("      ├┬┘├┤ ├─┤ ││   │ ├─┤├┤   └─┐ │ │ │├┬┘└┬┘  ├─┤│ ┬├─┤││││  ├┤ │ │├┬┘  ├─┤  │││├┤ │││  │ ││ │ │ │  │ ││││├┤ │");
                Console.WriteLine("      ┴└─└─┘┴ ┴─┴┘   ┴ ┴ ┴└─┘  └─┘ ┴ └─┘┴└─ ┴   ┴ ┴└─┘┴ ┴┴┘└┘  └  └─┘┴└─  ┴ ┴  ┘└┘└─┘└┴┘  └─┘└─┘ ┴ └─┘└─┘┴ ┴└─┘o");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            if (story[9].Contains(pageContents[0])) //change the 9 into something else, is hardcoded
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
            SplitString();
            Introduction();
            while (failState == false) //gameplay loop
            {
                while (pageNumber - 1 < maxPage) //loop is double nested to allow range checking on the page//consider splitting loop into 2 if statements so that story doesn't skip first page if improper input is detected in first choice.
                {
                    SplitString();
                    PrintPage(pageNumber);
                    SplitString();
                    EndGame(); //checks to see if the story is over
                    PlayerChoice();
                    ClearScreen(); //clears the screen for presentation purposes
                }
            } //gameplay loop

            Console.ReadKey(true);
        }
    }
}
