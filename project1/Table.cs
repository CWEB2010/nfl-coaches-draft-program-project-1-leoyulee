﻿using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    class Table
    {
        private static readonly int TabLength = 8;
        private static readonly int minDisplacement = 1;
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
            int charLong = 0;
            foreach (int column in minColumnLength)
            {
                charLong += column;
            }
            for (int i = -1; i < Rows.Count; i++)
            {
                PrintSeparator(TabLength * charLong);
                if (i == -1)
                {
                    PrintHeader();
                }
                else
                {
                    PrintRow(Rows[i]);
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
            for(int i = 0; i<input.Count; i++)
            {
                int j = i + 1;
                this.CalculateMinColumnLength(input[i].PrintInstitution(), j);
                this.CalculateMinColumnLength(input[i].PrintName(), j);
                this.CalculateMinColumnLength(input[i].PrintSalary(), j);
            }
        }
        private void CalculateMinColumnLength(string input, int column)
        {
            int stringLength = input.Length;
            int minLengthForInput = stringLength / 8;
            if(minColumnLength[column] < minLengthForInput + 1)
            {
                minColumnLength[column] = minLengthForInput + 1;
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
            for (int i = 0; i < Header.Length; i++)
            {
                outputString += createTab(minColumnLength[i], Header[i]);
            }
            Console.WriteLine(outputString);
        }
        private void PrintRow(Row row)
        {
            string[] outputs = new string[] { "", "", "" };

            List<Player> PlayerList = row.GetPlayerList();

            for (int i = 0; i < PlayerList.Count; i++)
            {
                int j = i + 1;
                if (i == 0)
                {
                    outputs[0] += createTab(minColumnLength[i], row.Label);
                    outputs[1] += createTab(minColumnLength[i]);
                    outputs[2] += createTab(minColumnLength[i]);
                }
                if (i != 4)
                {
                    outputs[0] += createTab(minColumnLength[j], PlayerList[i].PrintName());
                    outputs[1] += createTab(minColumnLength[j], PlayerList[i].PrintInstitution());
                    outputs[2] += createTab(minColumnLength[j], PlayerList[i].PrintSalary());
                }
                else
                {
                    outputs[0] += PlayerList[i].PrintName();
                    outputs[1] += PlayerList[i].PrintInstitution();
                    outputs[2] += PlayerList[i].PrintSalary();
                }
            }
            foreach (string output in outputs)
            {
                Console.WriteLine(output);
            }
        }
        private string createTab(int columnLength, string stringToBeFormatted = "")
        {
            string output = stringToBeFormatted;
            int minTab = (stringToBeFormatted.Length / 8) + minDisplacement;
            for (int i = 0; i - 1 < columnLength - minTab; i++)
            {
                output += "\t";
            }
            return output;
        }
    }
}