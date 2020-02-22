using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    class Shopper
    {
        public int MoneySpent;
        public int Money;
        public int SelectionMethod;
        private List<Player> SelectedPlayers;
        public Shopper(int Money, int SelectionMethod)
        {
            this.MoneySpent = 0;
            this.Money = Money;
            this.SelectionMethod = SelectionMethod;
            this.SelectedPlayers = new List<Player>();
        }
        public Shopper(int Money, int SelectionMethod, List<Player> ExistingList)
        {

            this.MoneySpent = 0;
            this.Money = Money;
            this.SelectionMethod = SelectionMethod;
            this.SelectedPlayers = ExistingList;
        }
        public void AddPlayer(Player input)
        {
            this.SelectedPlayers.Add(input);
        }
        public bool CheckForPlayer(string inputName)
        {
            return this.SelectedPlayers.Exists(p => p.Name == inputName);
        }
        public int NumSelectedPlayers()
        {

            return this.SelectedPlayers.Count;
        }
        public List<Player> GetPlayerList()
        {
            return this.SelectedPlayers;
        }
        public override string ToString()
        {
            string PlayerOutput = "";
            for (int i = 0; i < this.NumSelectedPlayers(); i++)
            {
                PlayerOutput += this.SelectedPlayers[i] + ", ";
            }
            return $"Money Spent: {MoneySpent}\n Money Left: {Money}\n Selected Players: " + PlayerOutput;
        }
    }
}
