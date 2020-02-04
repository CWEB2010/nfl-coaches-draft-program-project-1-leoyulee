using System;

namespace project1
{
    class Program
    {
        private static string response;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of players you would like to enter: ");
            response = Console.ReadLine();

            Player newPlayer = new Player();
            Console.WriteLine("Welcome! Insert the player's credentials here.");
            Console.ReadLine();
            Player Burrow = new Player("Burrow", "Joe", "LSU", "Quarterback", 26400100);
            Console.WriteLine("Hello World!");
            Console.WriteLine(Burrow.ToString());
            Console.Beep();
        }
    }
}
