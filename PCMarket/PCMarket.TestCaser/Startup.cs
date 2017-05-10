using System.Reflection;
using PCMarket.Models.Entities;

namespace PCMarket.TestCaser
{
    using System;
    using Common.Extensions;
    using Services.Managers;
    using Data;

    public class Startup
    {
        public static void Main()
        {
            TestSplitPascalCaseWords();
            //var fileManager = new TemproaryFileManager();
            //var fileBytes = fileManager.GetRetFileBytes(@"D:\User\Desktop\screen.png");
            //fileManager.UploadFile(fileBytes, @"D:\User\Desktop\23f.png");
            //FileManager fileManager = new FileManager();
            //Console.WriteLine(fileManager.CheckIfDirectoryExists("/pesho"));
            //Console.WriteLine(fileManager.CheckIfFileExists("/pesho/ombre/do10.txt"));
            //Console.WriteLine(fileManager.DeleteFolder("/pesho10superpower"));
            //Console.WriteLine(fileManager.SaveToFile(@"/pesho10superpower", "/App.config"));
        }

        private static void TestSplitPascalCaseWords()
        {
            string @string = "PascalCase";
            PrintCase(@string);
            string terry = "TerryHulkHogan";
            PrintCase(terry);
            var word3 = "Shoppen";
            PrintCase(word3);
            var word = "bigEndean";
            PrintCase(word);
            word = "bigEndeanAndLittleEndean";
            PrintCase(word);
        }

        public static void PrintCase(string word)
        {
            Console.WriteLine(@"------------------------------");
            Console.WriteLine(word);
            Console.WriteLine(@"------------------------------");
            Console.WriteLine(string.Join(", ", word.GetSplittedPascalCaseWords()));
            Console.WriteLine();
        }
    }
}