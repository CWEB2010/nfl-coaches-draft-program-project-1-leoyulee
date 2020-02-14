using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    class Table
    {
        private readonly int TabLength = 8;
        private static readonly String[] Header = { "Position", "The Best", "2nd Best", "3rd Best", "4th Best", "5th Best" };
        private int[] minColumnLength = new int[Header.Length];
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
                int charLong = 0;
                foreach (int column in minColumnLength)
                {
                    charLong += column;
                }
                PrintSeparator(TabLength * charLong);
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
            this.CalculateMinColumnLength(FilledRow.Label, 0);
            this.checkRowStrings(FilledRow.GetPlayerList());
        }
        private void checkRowStrings(List<Player> input)
        {
            for(int i = 1; i<input.Count; i++)
            {
                this.CalculateMinColumnLength(input[i].PrintInstitution(), i);
                this.CalculateMinColumnLength(input[i].PrintName(), i);
                this.CalculateMinColumnLength(input[i].PrintSalary(), i);
            }
        }
        private void CalculateMinColumnLength(string input, int column)
        {
            int stringLength = input.Length;
            int minLengthForInput = stringLength / 8;
            if(minColumnLength[column] < minLengthForInput + 1)
            {
                minColumnLength[column] = minLengthForInput + 1;
                Console.WriteLine("ColumnNum: " + column + ", Tabs: " + minLengthForInput);
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
                outputString += String;
                int minTab = String.Length / 8;
                for(int i = 0; i-1 < minColumnLength[i] - minTab; i++)
                {
                    outputString += "\t";
                }
            }
            Console.WriteLine(outputString);
        }
        private void PrintRow()
        {
            foreach (Row row in Rows)
            {
                foreach (Player player in row)
                {
                    string outputString = "";

                }
            }
        }
    }
}
