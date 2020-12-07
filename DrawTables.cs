using System;
using System.Linq;

namespace LP2_Exoplanets_2020
{
    public class DrawTable
    {
        public int tableWidth;

        /// <summary>
        /// Construct method
        /// </summary>
        /// <param name="tableWidth">recives value of the table width </param>
        public DrawTable(int tableWidth){
            this.tableWidth = tableWidth;
        }

        public void TableLines()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int columnWidth = (tableWidth - columns.Length) / columns.Length;
            const string columnSeperator = "|";

            string row = columns.Aggregate(columnSeperator, (seperator, columnText) => seperator + CenterText(columnText, columnWidth) + columnSeperator);

            Console.WriteLine(row);
        }

        private string CenterText(string text, int columnWidth)
        {
            text = text.Length > columnWidth ? text.Substring(0, columnWidth - 3) + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', columnWidth)
                : text.PadRight(columnWidth - ((columnWidth - text.Length) / 2)).PadLeft(columnWidth);
        }
    }
}