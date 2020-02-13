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
        static void Main(string[] args)
        {
            Table MainTable = new Table();
            Init(ref MainTable);
            MainTable.PrintTable();
            /*for(int i = 0; i < test3.GetLength(0); i++) 
            {
                for(int j = 0; j < test3.GetLength(1); j++)
                {
                    Console.WriteLine(test3[i, j]);
                }
            }*/
            
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
            String[] Positions = {
                "Quarterback",
                "Running Back",
                "Wide Reciever",
                "Defensive Lineman",
                "Defensive-Back",
                "Tight Ends",
                "Line-Backer",
                "Offensive Tackles"
            };
            Console.WriteLine("Hello World!");
            Console.Beep(294, 500);
            JObject playerRoster = JObject.Parse(file); //read the json string
            foreach (String Position in Positions)
            {
                IList<JToken> players = playerRoster[Position].Children().ToList(); //Get raw JSON data into a list
                List<Player> playerList = new List<Player>(); //Create raw list for data
                foreach (JToken player in players)
                {
                    Player Player = player.ToObject<Player>();
                    playerList.Add(Player); //Add the player into the list
                }
                playerList.TrimExcess();
                mainTable.AddRow(new Row(Position, playerList.ToArray()));
                /*
                //Debug: Print all of the players
                Console.WriteLine("\n" + Position);
                foreach (Player player in playerList)
                {
                    Console.WriteLine(player);
                }
                */
            }
        }
    }
    class Table
    {
        private readonly int TabLength = 22;
        private readonly String[] Header = { "Position", "The Best", "2nd Best", "3rd Best", "4th Best", "5th Best" };
        private List<Row> Rows;
        public Table()
        {
            this.Rows = new List<Row>();
        }
        public Table(Row[] FilledRows)
        {
            this.Rows = new List<Row>();
            foreach (Row row in FilledRows)
            {
                this.AddRow(row);
            }
        }
        public void PrintTable()
        {
            for(int i = -1; i<Rows.Count; i++)
            {
                PrintSeparator(TabLength * Header.Length);
                if (i == -1)
                {
                    PrintHeader();
                }
                else
                {
                    Rows[i].ToString();
                }
            }
        }
        public void AddRow(Row FilledRow)
        {
            this.Rows.Add(FilledRow);
            this.Rows.TrimExcess();
        }
        private void PrintSeparator(int length)
        {
            string output = "";
            for(int i = 0; i<length; i++)
            {
                output += "-";
            }
            Console.WriteLine("\n"+output);
        }
        private void PrintHeader()
        {
            string outputString = "";
            foreach(string String in Header)
            {
                outputString += String + "\t\t";
            }
            Console.WriteLine(outputString);
        }
    }
    class Row
    {
        public readonly string Label;
        private List<Player> Players;
        public Row(String Label, Player[] Players)
        {
            this.Label = Label;
            this.Players = new List<Player>();
            foreach (Player player in Players)
            {
                this.AddPlayer(player);
            }
            this.Players.TrimExcess();
        }
        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }
        public override string ToString()
        {
            
            return base.ToString();
        }
    }
}
