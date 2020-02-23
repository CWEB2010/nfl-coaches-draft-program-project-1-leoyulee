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
            this.MoneySpent += input.Salary;
            this.Money -= input.Salary;
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
        public bool CanContinue(int DraftLimit, out string Reason)
        {
            if (this.NumSelectedPlayers() >= DraftLimit)
            {
                Reason = "you have hit the draft limit.";
                return false;
            }
            if (this.Money <= 0)
            {
                Reason = "you have no funds left";
                return false;
            }
            Reason = null;
            return true;
        }
        public string ReturnEconomy()
        {
            return $"Money Spent: {MoneySpent}\nMoney Left: {Money}";
        }
        public override string ToString()
        {
            string PlayerOutput = "";
            for (int i = 0; i < this.NumSelectedPlayers(); i++)
            {
                PlayerOutput += "\n"+this.SelectedPlayers[i] + ",";
            }
            return $"Money Spent: {MoneySpent}\nMoney Left: {Money}\nSelected Players: " + PlayerOutput;
        }
    }
}
