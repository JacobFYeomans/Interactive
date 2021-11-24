using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program
    {
        static int pageNumber = 0; //current page - 1
        static int maxPage = 9; //for range checking purposes
        static string input;
        static string[] story = new string[10];
        static bool firstChoice = true;
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
        } //Code above ^^^^^^ is probably useless code, not deleting because it might be useful, but it is unlikely.
        static void PrintPage(int page) //calls the actual story
        {
            // Console.WriteLine(input); this calls on the input in StoryChoice(); and thus can be used to determine if choice 1 or 2 was chosen.
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("PAGE: " + (page + 1));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(story[page]);
            //if (page != 0)
            //{
            //    foreach (string x in pageContents)
            //    {
            //        if (x != null)
            //        {
            //            Console.WriteLine(x);
            //        }

            //    }
            //}
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }  
        static void StringSplitter(int page) //this makes it so the string printed is only split AFTER making a choice, which will pose problems if trying to print the string w/ a foreach loop or other method
        {
            pageContents = story[pageNumber].Split(';'); 
            int choice = int.Parse(pageContents[page]);
            pageNumber = choice - 1;
            PrintPage(pageNumber); //remove?
        }
        static void PlayerChoice() 
        {
            input = Console.ReadLine();
            switch (input)
            {
                case "1":

                    if (firstChoice == false)
                    {
                        StringSplitter(3); //extra credit: make this value not static/hard coded/anti-modular
                    }
                    if (firstChoice == true)
                    {
                        PrintPage(pageNumber);
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
                        StringSplitter(4); //extra credit: make this value not static/hard coded/anti-modular
                    }
                    break;

                default:
                    
                    if (firstChoice == true)
                    {
                        Console.WriteLine("Input not recognized, please chose option 1 to start or 2 to quit.");
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
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("A Short Tale of Variable Adventures");
            Console.WriteLine("By: Jacob. F. Yeomans");
            //Console.WriteLine("To access menu, enter '='");
            Console.ForegroundColor = ConsoleColor.White;
            story[0] = "You come accross a split path.;Go left.;Go right.;2;3"; //page 1
            story[1] = "After walking some time to the left, you come accross another split path.;Continue left.;Go right.;4;5"; //page 2
            story[2] = "After walking some time to the right, you come accross a large tree.;Continue past the tree.;Inspect the tree.;6;7"; //page 3
            story[3] = "You go left, the path is a dead end. Game over.;delete;this;10;10"; //page 4
            story[4] = "You go right, and find a pot of gold. You Win.;delete;this;10;10"; //page 5
            story[5] = "You continue past the tree are are attacked by a massive spider. Game Over.;delete;this;10;10"; //page 6
            story[6] = "You inspect the Tree, you see ancient text engraved on it.;Decypher the text.;Ignore it.;8;9"; //page 7
            story[7] = "The text tells you there's a large pot of gold on the other path, and that you wasted your time.;delete;this;10;10"; //page 8
            story[8] = "You ignore the text, and the tree comes to life and eats you. Game Over.;delete;this;10;10"; //page 9
            story[9] = "J: End Page"; //page 10
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Introduction();
            while (failState == false) //game loop
            {
                while (pageNumber - 1 <= maxPage) //loop is double nested to allow range checking on the page
                {
                    PlayerChoice();
                }
            }

            Console.ReadKey(true);
        }
    }
}
