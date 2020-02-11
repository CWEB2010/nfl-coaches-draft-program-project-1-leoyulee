using System;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Beep();
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
            this.Players = 
            foreach (Player player in Players)
            {
                
            }
        }
    }
}
