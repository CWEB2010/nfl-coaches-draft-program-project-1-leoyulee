using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
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
        private List<Player> GetPlayerList()
        {
            return Players;
        }
    }
}
