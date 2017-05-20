using System.Drawing;
using System.IO;

namespace PCMarket.TestCaser
{
    using System;
    using Common.Extensions;
    using Services.ImageWorker;

    public class Startup
    {
        //public static void ResizeImage(string imagepath)
        //{

        //    var lastPathDot = imagepath.LastIndexOf('.');
        //    var imagePathWithoutExtension = imagepath.Substring(0, lastPathDot);
        //    var extension = imagepath.Substring(lastPathDot, imagepath.Length - lastPathDot);
        //    string imageCurrentSizeInRectangleFormat =
        //        $"{imagePathWithoutExtension}cs{extension}";
        //    // 200x200
        //    string middleSize = $"{imagePathWithoutExtension}ms{extension}";
        //    // 125x125
        //    string smallSize = $"{imagePathWithoutExtension}ss{extension}";
        //    // 75x75
        //    string tinySize = $"{imagePathWithoutExtension}ts{extension}";

        //    var image = new ImageFactory().Load(imagepath);
        //    var isHeightLargerThanWidth = image.Image.Width < image.Image.Height;
        //    var sizeDiff = Math.Abs(image.Image.Width - image.Image.Height);
        //    var halfDiffSize = sizeDiff / 2;
        //    if (isHeightLargerThanWidth)
        //    {
        //        image.Crop(new Rectangle(
        //                0,
        //                halfDiffSize,
        //                image.Image.Height - sizeDiff,
        //                image.Image.Width))
        //            .Resize(MiddleSize)
        //            .Save(middleSize);
        //        image.Resize(SmallSize).Save(smallSize);
        //        image.Resize(TinySize).Save(tinySize);
        //    }
        //    else
        //    {
        //        image.Crop(new Rectangle(
        //                halfDiffSize,
        //                0,
        //                image.Image.Height,
        //                image.Image.Width - sizeDiff))
        //            .Resize(MiddleSize)
        //            .Save(middleSize);
        //        image.Resize(SmallSize).Save(smallSize);
        //        image.Resize(TinySize).Save(tinySize);
        //    }
        //}

        public static void Main()
        {
            //ResizeImage(@"D:\User\Desktop\AbstractWallpapers.jpg");
            ImageManager manager = new ImageManager(@"D:\User\Desktop");
            var rectangled = manager.Load(@"mario.jpg").GetRectangled().InnerImage;
            var middleSized = manager.MiddlewareReload(rectangled).GetMiddleSizedImage();
            var smallSized = manager.MiddlewareReload(rectangled).GetSmallSizedImage();
            var tinySized = manager.MiddlewareReload(rectangled).GetTinySizedImage();
            manager.MiddlewareReload(middleSized)
                .AsPng()
                .SaveTo("marioms.png");
            manager.MiddlewareReload(smallSized)
                .AsPng()
                .SaveTo("marioss.png");
            manager.MiddlewareReload(tinySized)
                .AsPng()
                .SaveTo("mariots.png");

            //File.AppendAllText(@"D:\User\Desktop\mariobase64.txt", imageBase64);
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