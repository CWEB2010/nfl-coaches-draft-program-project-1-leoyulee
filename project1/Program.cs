using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\leeleoy\Desktop\Advanced Programming Project 1\project1\Roster.json";
            String[] Positions = { "Quarterback", "Running Back" };
            Console.WriteLine("Hello World!");
            /*var test = new Player("Quarterback", 0, "Joe Burrow", "LSU", 26400100);
            var str = JsonConvert.SerializeObject(test, Formatting.Indented);
            Console.WriteLine(str);
            Console.Beep();
            var test2 = JsonConvert.DeserializeObject<Player>(str);
            Console.WriteLine(test2);
            Console.Beep(440, 500);
            //File.WriteAllText(path, str); //Write the json string*/
            Console.Beep(294, 500);
            //JObject documentation: https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm
            //Deserializing partial JSON fragments documentation: https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
            JObject playerRoster = JObject.Parse(File.ReadAllText(path));//read the json string
            foreach(String Position in Positions)
            {
                IList<JToken> players = playerRoster[Position].Children().ToList(); //Get raw JSON data into a list
                IList<Player> playerList = new List<Player>(); //Create raw list for data
                foreach (JToken player in players)
                {
                    Player Player = player.ToObject<Player>();
                    playerList.Add(Player);
                }
                Console.WriteLine("\n"+Position);
                foreach (Player player in playerList)
                {
                    Console.WriteLine(player);
                }
            }
            
            /*for(int i = 0; i < test3.GetLength(0); i++) 
            {
                for(int j = 0; j < test3.GetLength(1); j++)
                {
                    Console.WriteLine(test3[i, j]);
                }
            }*/
            
        }
    }
    class Table
    {
        private readonly String[] Header = { "Position", "The Best", "2nd Best", "3rd Best", "4th Best", "5th Best" };
        Row[] Rows;
        public Table(Row[] args)
        {
            this.Rows = args;
        }
    }
    class Row
    {
        private readonly string Label;
        private Player[] Players;
        public Row(String Label, Player[] Players)
        {
            this.Label = Label;
            this.Players = Players;
            foreach (Player player in Players)
            {
                
            }
        }
    }
}
