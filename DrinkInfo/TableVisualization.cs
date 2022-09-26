﻿using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkInfo
{
    internal class TableVisualization
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T: class
        {
            Console.Clear();

            if (tableName == null)
                tableName = "";
            Console.WriteLine("\n\n");
            ConsoleTableBuilder
                .From(tableData)
                .WithColumn(tableName)
                .ExportAndWriteLine();
            Console.WriteLine("\n\n");
        }
    }
}
