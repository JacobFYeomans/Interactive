using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive
{
    class Program //make text appear slowly
    {
        static int pageNumber = 0; //current page, displayed value is +1 to prevent a page 0 from existing.
        static string input;
        static string[] story = File.ReadAllLines(@"story.txt"); //parse # of lines read, make maxPages = # of lines read.
        static int maxPage = story.Length; //for range checking purposes
        static string savePage;
        static bool firstChoice = true;
        static int choice;
        static string[] pageContents;
        static bool failState = false; //the game runs on a while loop that requires this to be false
        static string storyHash = File.ReadAllText(@"story.txt"); //merge the reads into one and split elsewhere with a new delimiter
        static byte[] tmpSource;
        static byte[] tmpHash;


        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

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
            Console.WriteLine("                           All choices are made using the buttons '1' or '2'.");
            Console.WriteLine("  Additionally, during the story you can save by pressing '3', and return to main menu by pressing '4'");
            Console.ForegroundColor = ConsoleColor.White;
        } 
        static void HashCheck()
        {
            tmpSource = ASCIIEncoding.ASCII.GetBytes(storyHash);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            if (ByteArrayToString(tmpHash) != "FC5BC3119A3C3DCA38B1B59DC2146815")
            {
                Console.WriteLine("Story is Corrupted");
                failState = true;
            }
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
        static void PrintMainMenu()
        {
            PrintIntroInfo();
            Introduction();
        }
        static void StoryChecking()
        {
            if (!File.Exists(@"story.txt"))
            {
                Console.WriteLine("the story file has been deleted. Please redownload to resolve issue");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            HashCheck();
        }
        static void SaveChecking()
        {
            if (!File.Exists(@"save.txt"))
            {
                string newSaveInitialization = "0";
                File.WriteAllText(@"save.txt", newSaveInitialization);
            }
            string saveChecking = File.ReadAllText(@"save.txt");
            try
            {
                int saveValueChecking = int.Parse(saveChecking);
            }
            catch
            {
                string newSaveInitialization = "0";
                File.WriteAllText(@"save.txt", newSaveInitialization);
            }
            int saveValueChecking2 = int.Parse(saveChecking);
            if (saveValueChecking2 < 0 || saveValueChecking2 > maxPage)
            {
                string newSaveInitialization = "0";
                File.WriteAllText(@"save.txt", newSaveInitialization);
            }


            //if (saveChecking.Length == 0 || saveChecking.Length >= 2)
            //{
            //    string newSaveInitialization = "0";
            //    File.WriteAllText(@"save.txt", newSaveInitialization);
            //}
            //int saveValueChecking = int.Parse(saveChecking);
            //if (saveValueChecking < 0 || saveValueChecking > maxPage)
            //{
            //    string newSaveInitialization = "1";
            //    File.WriteAllText(@"save.txt", newSaveInitialization);
            //}
        }
        static void PrintPage(int page)
        {
            if (page != -1 && firstChoice == false) 
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("PAGE: " + (page + 1)); // done so that there is no page 0
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (string x in pageContents)
                {
                    if (x != null && x != pageContents[pageContents.Length - 2] && x != pageContents[pageContents.Length - 1]) // X != null is to prevent an issue in which x can be null, the x != pageContents[pageContents.Length - 2] && x != pageContents[pageContents.Length - 1] is to make it so the page options are never printed
                    {
                        if (x == pageContents[pageContents.Length - 3] || x == pageContents[pageContents.Length - 4])
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(x);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(x);
                            Console.WriteLine();
                        }
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
            choice = int.Parse(pageContents[pageContents.Length - page]);
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
                        DefineChoice(2); //Anti-Modular
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
                        DefineChoice(1); 
                    }
                    break;

                case "3":

                    if (firstChoice == false)
                    {
                        SaveGame();
                    }
                    if (firstChoice == true)
                    {
                        firstChoice = false;
                        LoadGame();
                    }
                    break;

                case "4":

                    if (firstChoice == false)
                    {
                        Environment.Exit(0);
                    }
                    break;

                default:
                    
                    if (firstChoice == true)
                    {
                        Console.WriteLine("Input not recognized, please chose option 1 to start or 2 to quit."); // skips first page if improper input and you started, and loading save file doesn't work after improper input & and looping after an ending
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
        static void ResetGame() //resets story
        {
            pageNumber = 0;
            pageContents = story[pageNumber].Split(';');
            firstChoice = true;
        }
        static void ReturnMainMenu()
        {
            ClearScreen();
            ResetGame();
            PrintMainMenu();
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
            savePage = File.ReadAllText(@"save.txt");
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
                ReturnMainMenu();
            }
            if (story[9].Contains(pageContents[0])) //change the 9 into something else, is hardcoded
            {
                Console.WriteLine("                                   ┬ ┬┌─┐┬ ┬┬─┐   ┬┌─┐┬ ┬┬─┐┌┐┌┌─┐┬ ┬  ┬┌─┐  ┌─┐┬  ┬┌─┐┬─┐");
                Console.WriteLine("                                   └┬┘│ ││ │├┬┘   ││ ││ │├┬┘│││├┤ └┬┘  │└─┐  │ │└┐┌┘├┤ ├┬┘");
                Console.WriteLine("                                    ┴ └─┘└─┘┴└─  └┘└─┘└─┘┴└─┘└┘└─┘ ┴   ┴└─┘  └─┘ └┘ └─┘┴└─");
                Console.ReadKey(true);
                ReturnMainMenu();
            }
        }
        static void Main(string[] args)
        {
            StoryChecking();
            SaveChecking();
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
