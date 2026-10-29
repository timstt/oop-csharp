using System;
using System.IO;

namespace Lab5.V1
{
    public static class Service
    {
        private const string FilePath = "results_lab5.txt";

        public static void SaveAndPrint(string message)
        {
            Console.WriteLine(message);
            File.AppendAllText(FilePath, message + "\n");
        }

        public static void ClearLog() => File.Delete(FilePath);
    }
}