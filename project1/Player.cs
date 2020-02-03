using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    class Player
    {
        private string lastName;
        private string firstName;
        private string homeState;
        private string position;
        private int salary;
        
        public Player(string lastName, string firstName, string homeState, string position, int salary)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.homeState = homeState;
            this.position = position;
            this.salary = salary;
        }
        public string getName(in bool lastFirst)
        {
            if (lastFirst)
            {
                return this.lastName + ", " + this.firstName;
            }
            return this.firstName + " " + this.lastName;
        }
        public string getHome()
        {
            return this.homeState;
        }
        public string getPosition()
        {
            return this.position;
        }
        public int getSalary()
        {
            string stringedSalary = salary.ToString();
            string formattedSalary =
            return this.salary;
        }
        override public string ToString()
        {
            return this.firstName + " " + this.lastName + ", " + this.homeState + ", " + this.position + ", $" + this.getSalary();
        }
    }
}
