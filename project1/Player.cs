using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    public class Player
    {
        //Readonly tutorial reference https://www.tutlane.com/tutorial/csharp/csharp-readonly-property
        public readonly string Position;
        public readonly int Ranking;
        public readonly string Name;
        public readonly string Institution;
        public readonly int Salary;
        public Player(string Position, int Ranking, string Name, string Institution, int Salary)
        {
            this.Position = Position;
            this.Ranking = Ranking;
            this.Name = Name;
            this.Institution = Institution;
            this.Salary = Salary;
        }
        /*public Player(string Name, string Institution, int Salary)
        {
            this.Name = Name;
            this.Institution = Institution;
            this.Salary = Salary;
        }*/
        public override string ToString()
        {
            return $"{Name}\n({Institution})\n${Salary}";
        }
    }
    /*class Quarterback : Player
    {
        public readonly int Ranking; //0 being best, 4 being 5th best
        
        public Quarterback(int Ranking, string Name, string Institution, int Salary)
            :base(Name, Institution, Salary)

        {
            this.Ranking = Ranking;
        }
    }
    class RunningBack : Player
    {
        public readonly int Ranking; //0 being best, 4 being 5th best

        public RunningBack(int Ranking, string Name, string Institution, int Salary)
            : base(Name, Institution, Salary)

        {
            this.Ranking = Ranking;
        }
    }*/
}
