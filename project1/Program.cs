using System;
using System.IO;
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
            Console.WriteLine("Hello World!");
            var test = new Player("Quarterback", 0, "Joe Burrow", "LSU", 26400100);
            var str = JsonConvert.SerializeObject(test, Formatting.Indented);
            Console.WriteLine(str);
            Console.Beep();
            var test2 = JsonConvert.DeserializeObject<Player>(str);
            Console.WriteLine(test2);
            Console.Beep(440, 500);
            File.WriteAllText(path, str);
            Console.Beep(294, 500);
            var test3 = JsonConvert.DeserializeObject<Player>(File.ReadAllText(path));
            Console.WriteLine(test3);
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
