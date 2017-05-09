namespace PCMarket.TestCaser
{
    using System;
    using Common.Extensions;
    using Services.Features;

    public class Startup
    {
        public static void Main()
        {
            TestSplitPascalCaseWords();
            TestDropboxService();
        }

        private static void TestDropboxService()
        {
            var dropbox = new DropboxClientService();
            var files = dropbox.Files.ListFolderAsync("/peshofolder").Result;
            foreach (var entry in files.Entries)
            {
                Console.WriteLine(entry.Name);
            }
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