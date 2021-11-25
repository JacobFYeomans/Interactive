using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program //string.contains can be used to find keywords within strings to create win and lose states
    {
        static int pageNumber = 0; //current page - 1
        static int maxPage = 19; //for range checking purposes
        static string input;
        static string[] story = new string[19];
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
        static void StoryInitializtion()
        {
            story [0] = "October 17th, Imperial Year 1717. You, Hero Kels, depart on a journey to slay the demon lord.;1: Rush for the demon continent.;2: Attempt to save the people of your homeland.;2;3"; //page 1
            story [1] = "Rushing toward your eternal adversary, you chose the mode of travel you believe will take you to the Demon continent thefastest.;1: Get on a boat.;2: Join a caravan.;4;5"; //page 2
            story [2] = "You ceasely run around, trying to help the people of your nation. The demon lord becomes more bold due to your lack of action;1: Continue helping.;2: Rush to fight the demon lord.;10;2"; //page 3
            story [3] = "Getting on your chosen vessel, you are attacked by the demon lord's right hand demon, how do you react.;1: Reveal your prescense and save the day!;2: Allow the demon to slaughter the crew without being noticed, and then commendeer the boat to continue your journey.;6;7"; //page 4
            story [4] = "You join a travelling trade caravan. The people of the caravan are friendly and helpful. When you arrive near the demon continent, what do you do?.;1: Safely see them to their destination.;2: Leave without a word.;11;12"; //page 5
            story [5] = "The demon lord's right hand demon notices you and decides to sink the ship.;1: Try to save the lives of the crew.;2: Try to save your own life.;10;10"; //page 6
            story [6] = "You watch as the crew is slaughtered, but escape unharmed. What do you do?;1: Steer the ship towards the demon continent.;2: Jump overboard and swim towards the demon continent.;9;10"; //page 7
            story [7] = "I ended up not using this page, but I don't want to remove it since it requires me restructing the entire string.;1: delete;2: this;10;10"; //page 8
            story [8] = "You do not know how to pilot a ship and crash into an island. What do you do?.;1: Give up and live on the island forever.;2: Swim to safety.;10;10"; //page 9
            story [9] = "Your efforts end in vain. The demon lord reigns victorious.;x;x;x;x"; //page 10 & bad ending page
            story [10] = "You travel with the caravan to their destination, even though it gives the demon lord more time to act. What do you do once you arrive in town safely with the caravan?;1: Stock up on supplies;2: Rush the demon lord's castle.;13;14"; //page 11
            story [11] = "Though you feel guilty, you leave the caravan quietly and head towards the demon lords castle. How will you attack the demon lord's castle?;1: Brazenly;2: Stealthily;14;14"; //page 12
            story [12] = "Since this town is in the demon continent, the supplies are very powerful. With newfound tools inhand, how will you attack the demon lord's castle?;1: Brazenly;2: Stealthily;14;14"; //page 13
            story [13] = "You begin your attack the demon lord's castle. Eventually, after a long and gruelling effort, you find yourself face to face with the demon lord. What do you do?;1: Attack.;2: Try to bargain for peace.;15;17"; //page 14
            story [14] = "You attack the demon lord with everything you have...;1: Wait for the result.;2: Wait for the result.;16;16"; //page 15
            story [15] = "Even with all your might, the demon lord does not fall.;1: Struggle until the end.;2: Try one more time, with everything you have left.;10;10"; //page 16
            story [16] = "The demon lord is amicable to peace, and your journey is at its end;1: Celebrate peace with the demon lord.;2: Return home and celebrate peace with your family;18;18"; //page 17
            story [17] = "The celebration of peace grows to magnitudes never before seen, and becomes a yearly tradition that endures for many, many centuries to come.;1: Party until your drunk.;2: Leave and go on a new adventure.;19;19"; //page 18
            story [18] = "The End.;x;x;x;x"; //page 19
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
                        Console.WriteLine(x);
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
        }
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
            StoryInitializtion();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            StringSplitter();
            Introduction();
            while (failState == false) //gameplay loop
            {
                while (pageNumber - 1 < maxPage) //loop is double nested to allow range checking on the page//array will go out of bounds before while loop breaks
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
