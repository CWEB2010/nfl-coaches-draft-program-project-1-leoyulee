using System;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Burrow = new Player("Burrow", "Joe", "LSU", "Quarterback", 26400100);
            Console.WriteLine("Hello World!");
            Console.WriteLine(Burrow.ToString());
            Console.Beep();
        }
    }
}
