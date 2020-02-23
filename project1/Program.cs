using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Resources;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace project1
{
    class Program
    {
        enum InputMethods {Name, Position}
        private static readonly String[] Positions = {
                "Quarterback",
                "Running Back",
                "Wide Reciever",
                "Defensive Lineman",
                "Defensive-Back",
                "Tight Ends",
                "Line-Backer",
                "Offensive Tackles"
            };
        private static int DraftLimit = 5;
        private static int StartingCurrency = 95000000;
        static void Main()
        {
            Console.Clear();
            Table MainTable = new Table();
            Console.WriteLine("Welcome to the NFL drafter planner!");
            Console.WriteLine("How would you like to pick your players?");
            int InputMethod = Prompt(true, "Typing their name", "[NOT WORKING/INDEV] Selecting their position and ranking");
            Shopper Shopper = new Shopper(StartingCurrency, InputMethod);
            Init(ref MainTable);
            MainMenu(ref MainTable, ref Shopper);
            /*for(int i = 0; i < test3.GetLength(0); i++) 
            {
                for(int j = 0; j < test3.GetLength(1); j++)
                {
                    Console.WriteLine(test3[i, j]);
                }
            }*/
            
        }
        private static void Checkout(ref Table Table, ref Shopper Shopper, string Reason)
        {
            Console.Clear();
            Console.WriteLine("Your session has been concluded because " + Reason);
            List<Player> PlayerSelection = Shopper.GetPlayerList();
            List<Player> gotbest = new List<Player>();
            Console.WriteLine("Here is how much you spent have have left:");
            Console.WriteLine(Shopper.ReturnEconomy());
            Console.WriteLine("Here are the players you've selected:");
            foreach(Player player in PlayerSelection)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine(player.ToString());
                if (player.Ranking <= 3)
                {
                    gotbest.Add(player);
                }
            }
            if(gotbest.Count >= 3)
            {
                Console.WriteLine("\nYour selection was cost effective!");
            }
            Console.WriteLine("Would you like to try a different selection?");
            int response = Prompt(true, "Yes", "No");
            if (response == 0)
            {
                Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        private static void MainMenu(ref Table Table, ref Shopper Shopper, bool error = false)
        {
            
            Table.PrintTable(Shopper.GetPlayerList());
            InputMethods[] Methods = (InputMethods[])InputMethods.GetValues(typeof(InputMethods));
            Console.WriteLine(Shopper.ToString());
            Console.WriteLine("Type in the {0} of the player you would like to add to your roster. Type in Done when you're done.", Methods[Shopper.SelectionMethod]);
            if (Shopper.CanContinue(DraftLimit, out string Reason))
            {
                if (Shopper.SelectionMethod == 0)
                {
                    SelectByName(ref Table, ref Shopper);
                }
                else if (Shopper.SelectionMethod == 1)
                {
                    Console.WriteLine("This feature hasn't been implimented yet. Shutting program down...");
                    Console.ReadKey();
                    Console.ReadKey();
                }
            }
            else
            {
                Checkout(ref Table, ref Shopper, Reason);
            }
        }
        private static void SelectByName(ref Table Table, ref Shopper Shopper, bool error = false, string reason = null)
        {
            PrintError(error, reason);
            String UserResponse = GetStrResponse();
            if(UserResponse == "Done")
            {
                Checkout(ref Table, ref Shopper, "you've inputed \"Done\" in.");
            }
            Player SelectedPlayer = Table.GetPlayerByName(UserResponse);
            if (SelectedPlayer == null || Shopper.CheckForPlayer(SelectedPlayer.Name))
            {
                SelectByName(ref Table, ref Shopper, true);
            }
            else if (SelectedPlayer.Salary > Shopper.Money)
            {
                SelectByName(ref Table, ref Shopper, true, "You don't have enough funds for drafting that player");
            }
            else
            {
                Shopper.AddPlayer(SelectedPlayer.Copy());
            }
            MainMenu(ref Table, ref Shopper);
        }
        private static int Prompt(bool subtractOne, params string[] args)
        {
            int argsLength = args.Length;
            if (argsLength == 1)
            {
                Console.WriteLine("Note to developer: You shouldn't be using this method if you're going to put only one argument in");
            }
            Console.WriteLine("Enter one button, 1 through {0}, to make your selection.", argsLength);
            for(int i = 0; i < argsLength; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, args[i]);
            }
            int response = GetIntResponse(1, argsLength); //insert button pressing method here
            if (subtractOne)
            {
                response--;
            }
            return response;
        }
        private static int GetIntResponse(int min, int max, bool error = false)
        {
            PrintError(error);
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int response))
            {
                return response;
            }
            else
            {
                return GetIntResponse(min, max, true);
            }
        }
        private static string GetStrResponse(bool error = false)
        {
            PrintError(error);
            string userInput = Console.ReadLine();
            return userInput;
        }
        private static void PrintError(bool error = false, string reason = "Invalid input. Please try again.")
        {
            if (error)
            {
                Console.WriteLine(reason);
            }
        }
        private static void Init(ref Table mainTable)
        {
            //JObject documentation: https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm
            //Deserializing partial JSON fragments documentation: https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
            //Embedded Resource Files help: https://stackoverflow.com/questions/38762368/embedded-resource-in-net-core-libraries
            /*string[] names = assembly.GetManifestResourceNames(); //Get the resource names for debug
            foreach (string Name in names)
            {
                Console.WriteLine(Name);
            }*/
            var assembly = Assembly.GetExecutingAssembly(); //Get the core address
            string file;
            var resourceName = "project1.Roster.json"; //The file name

            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) //Get the file path in assembly code
            using (StreamReader reader = new StreamReader(stream)) //Get the file itself
            {
                file = reader.ReadToEnd(); //Convert the file into a string
                //Console.WriteLine(file); //debug
            }
            
            JObject playerRoster = JObject.Parse(file); //read the json string
            foreach (String Position in Positions)
            {
                IList<JToken> players = playerRoster[Position].Children().ToList(); //Get raw JSON data into a list
                List<Player> playerList = new List<Player>(); //Create raw list for data
                int i = 0;
                foreach (JToken player in players)
                {
                    Player _ = player.ToObject<Player>();
                    playerList.Add(_.FromJson(Position, i)); //Add the player into the list
                    i++;
                }
                playerList.TrimExcess();
                mainTable.AddRow(new Row(Position, playerList.ToArray()));
                
                /*
                //Debug: Print all of the players
                //Console.WriteLine("\n" + Position);
                foreach (Player player in playerList)
                {
                    Console.WriteLine(player);
                }
                */
            }
        }
    }
}
