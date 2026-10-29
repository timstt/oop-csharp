using System;
using System.IO;

namespace Lab4.V4
{
    public static class Service
    {
        private const string FilePath = "results.txt";

        public static void SaveAndPrint(string message)
        {
            Console.WriteLine(message);
            File.AppendAllText(FilePath, message + "\n");
        }

        public static void ClearLog()
        {
            File.Delete(FilePath);
        }
    }
}