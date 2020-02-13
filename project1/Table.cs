using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    class Table
    {
        private readonly int TabLength = 8;
        private readonly String[] Header = { "Position", "The Best", "2nd Best", "3rd Best", "4th Best", "5th Best" };
        private int minColumnLength;
        private List<Row> Rows;
        public Table()
        {
            this.Rows = new List<Row>();
        }
        public Table(Row[] FilledRows)
        {
            this.Rows = new List<Row>();
            foreach (Row row in FilledRows)
            {
                this.AddRow(row);
            }
        }
        public void PrintTable()
        {
            for (int i = -1; i < Rows.Count; i++)
            {
                PrintSeparator(TabLength * Header.Length);
                if (i == -1)
                {
                    PrintHeader();
                }
                else
                {
                    Rows[i].ToString();
                }
            }
        }
        public void AddRow(Row FilledRow)
        {
            this.Rows.Add(FilledRow);
            this.Rows.TrimExcess();
        }
        private void checkRowStrings(List<Player> input)
        {
            foreach(Player player in input)
            {
                this.CalculateMinColumnLength(player.Institution);
                this.CalculateMinColumnLength(player.Name);
            }
        }
        private void CalculateMinColumnLength(string input)
        {
            int stringLength = input.Length;
            int minLengthForInput = stringLength / 8;
            if(minColumnLength < minLengthForInput)
            {
                minColumnLength = minLengthForInput;
            }
        }
        private void PrintSeparator(int length)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output += "-";
            }
            Console.WriteLine("\n" + output);
        }
        private void PrintHeader()
        {
            string outputString = "";
            foreach (string String in Header)
            {
                outputString += String + "\t\t";
            }
            Console.WriteLine(outputString);
        }
    }
}
