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

        static void Main()
        {
            Table MainTable = new Table();
            Init(ref MainTable);
            MainMenu(ref MainTable, out int InputMethod);
            /*for(int i = 0; i < test3.GetLength(0); i++) 
            {
                for(int j = 0; j < test3.GetLength(1); j++)
                {
                    Console.WriteLine(test3[i, j]);
                }
            }*/
            
        }
        
        private static void MainMenu(ref Table Table, out int InputMethod, bool error = false)
        {
            Table.PrintTable();
            Console.WriteLine("Welcome to the NFL drafter planner!");
            Console.WriteLine("How would you like to pick your players?");
            InputMethod = Prompt(true, "Typing their name", "Selecting their position and ranking");
            Console.WriteLine($"Type in the {0} of the player you would like to add to your roster.", (InputMethods)InputMethod);
            if (InputMethod == 1)
            {
                
            }else if(InputMethod == 2)
            {
                Console.WriteLine($"Type in the Position and the Ranking of the player you would like to add to your roster.");
            }
        }
        private static int Prompt(bool subtractOne, params string[] args)
        {
            int argsLength = args.Length;
            if (argsLength == 1)
            {
                Console.WriteLine("Note to developer: You shouldn't be using this method if you're going to put only one argument in");
            }
            Console.WriteLine($"Press one button, 1 through {0}, to make your selection.", argsLength);
            int response = 0; //insert button pressing method here
            if (subtractOne)
            {
                response--;
            }
            return response;
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
