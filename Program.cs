using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program
    {
        static int pageNumber = 1; //current page - 1
        static int maxPage = 9; //for range checking purposes
        static string input;
        static string[] story = new string[10];
        //static int firstChoice;
        //static int secondChoice;
        static bool failState = false; //the game runs on a while loop that requires this to be false
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
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Page(int page) //calls the actual story
        {
            // Console.WriteLine(input); this calls on the input in StoryChoice(); and thus can be used to determine if choice 1 or 2 was chosen.
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("PAGE: " + page);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(story[page - 1]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        static void ChoiceStart() //merge w/ story choice, duplicate code bad
        {
            input = Console.ReadLine();
            switch (input)
            {
                case "1":

                    Page(pageNumber);
                    break;

                case "2":

                    Environment.Exit(0);
                    break;

                default:

                    Console.WriteLine("Input not recognized, please chose option 1 to start or 2 to quit.");
                    ChoiceStart();
                    break;
            }
        } //to chose start/quit on game load, will eventually include load from save.
        static void StoryChoice()
        {
            input = Console.ReadLine(); //manages all other choices. Will eventually have a save function added.
            switch (input)
            {
                case "1":

                    //do something here, do not hard code
                    Page(pageNumber);
                    break;

                case "2":

                    //do something here, do not hard code
                    Page(pageNumber);
                    break;

                default:

                    Console.WriteLine("Input not recognized, please chose option 1 or 2");
                    StoryChoice();
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("A Short Tale of Variable Adventures");
            Console.WriteLine("By: Jacob. F. Yeomans");
            //Console.WriteLine("To access menu, enter '='");
            Console.ForegroundColor = ConsoleColor.White;
            story[0] = "A: You come accross a split path, will you go left(1) or right(2)?"; //page 0
            story[1] = "B: After walking some time to the left, you come accross another split path, will you go left(1) or right(2)."; //page 1
            story[2] = "C: After walking some time to the right, you come accross a large tree. Will you continue past the tree(1), or inspect it?(2)"; //page 2
            story[3] = "D: You go left, the path is a dead end. Game over."; //page 3
            story[4] = "E: You go right, and find a pot of gold. You Win"; //page 4
            story[5] = "F: You continue past the tree are are attacked by a massive spider. Game Over."; //page 5
            story[6] = "E: You inspect the Tree, you see ancient text engraved on it. Do you try to decypher the text(1) or Ignore it(2)"; //page 6
            story[7] = "H: The text tells you there's a large pot of gold on the other path, and that you wasted your time."; //page 7
            story[8] = "I: You ignore the text, and the tree comes to life and eats you."; //page 8
            story[9] = "J: End Page"; //page 9
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


            Introduction();
            ChoiceStart();
            while (failState == false) //game loop
            {
                while (pageNumber - 1 <= maxPage) //loop is double nested to allow range checking on the page
                {
                    StoryChoice();
                }
            }

            Console.ReadKey(true);
        }
    }
}
