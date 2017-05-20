using System.IO;

namespace PCMarket.Services.ImageWorker
{
    using System;
    using System.Drawing;
    using ImageProcessor;
    using ImageProcessor.Imaging.Formats;

    public class ImageManager : IDisposable, IFluentManager
    {
        private readonly string directoryPath;
        private readonly Size middleSize;
        private readonly Size smallSize;
        private readonly Size tinySize;

        public ImageManager(string workDirectoryPath)
        {
            this.directoryPath = workDirectoryPath;
            this.Factory = new ImageFactory();
            this.middleSize = new Size(200, 200);
            this.smallSize = new Size(125, 125);
            this.tinySize = new Size(75, 75);
        }

        internal ImageFactory Factory { get; private set; }

        public Image InnerImage { get; private set; }

        public ImageManager Load(string filepath)
        {
            string fullPath = $"{this.directoryPath}\\{filepath}";
            bool isUsedWithWorkPath = new FileInfo($"{this.directoryPath}\\{filepath}").Exists;
            if (!isUsedWithWorkPath)
            {
                bool isUsedWithoutWorkPath = new FileInfo(filepath).Exists;
                if (!isUsedWithoutWorkPath)
                {
                    throw new FileNotFoundException("Wrong path or file-name.");
                }

                this.InnerImage = this.Factory.Load(filepath).Image;
            }

            this.InnerImage = this.Factory.Load(fullPath).Image;
            return this;
        }

        public ImageManager MiddlewareReload(Image image)
        {
            this.InnerImage = this.Factory.Load(image).Image;
            return this;
        }

        public ImageManager AsPng()
        {
            this.InnerImage = this.Factory.Format(new PngFormat()).Image;
            return this;
        }

        public ImageManager AsTiff()
        {
            this.InnerImage = this.Factory.Format(new TiffFormat()).Image;
            return this;
        }

        public ImageManager AsBitmap()
        {
            this.InnerImage = this.Factory.Format(new BitmapFormat()).Image;
            return this;
        }

        public ImageManager AsGif()
        {
            this.InnerImage = this.Factory.Format(new PngFormat()).Image;
            return this;
        }

        public ImageManager AsJpeg()
        {
            this.InnerImage = this.Factory.Format(new JpegFormat()).Image;
            return this;
        }

        public Image GetMiddleSizedImage()
        {
            return new ImageFactory().Load(this.InnerImage).Resize(middleSize).Image;
        }

        public Image GetSmallSizedImage()
        {
            return new ImageFactory().Load(this.InnerImage).Resize(smallSize).Image;
        }

        public Image GetTinySizedImage()
        {
            return new ImageFactory().Load(this.InnerImage).Resize(tinySize).Image;
        }

        public ImageManager Crop(int x, int y, int width, int height)
        {
            this.InnerImage = this.Factory.Crop(new Rectangle(x, y, width, height)).Image;
            return this;
        }

        public ImageManager GetRectangled()
        {
            int smallerSide = this.IsHeightLargerThanWidth() ? this.InnerImage.Width : this.InnerImage.Height;
            var sizeDiff = Math.Abs(this.Factory.Image.Width - this.Factory.Image.Height);
            var halfDiffSize = sizeDiff / 2;
            if (this.IsHeightLargerThanWidth())
            {
                this.InnerImage = this.Crop(
                    0,
                    halfDiffSize,
                    this.InnerImage.Width - sizeDiff,
                    this.InnerImage.Height).InnerImage;
            }
            else
            {
                this.InnerImage = this.Crop(
                    halfDiffSize,
                    0,
                    this.InnerImage.Width,
                    this.InnerImage.Height - sizeDiff).InnerImage;
            }

            return this;
        }

        public ImageManager GetRectangled(int width, int height)
        {
            var sizeDiff = Math.Abs(this.Factory.Image.Width - this.Factory.Image.Height);
            var halfDiffSize = sizeDiff / 2;
            if (this.IsHeightLargerThanWidth())
            {
                this.Crop(
                    0,
                    halfDiffSize,
                    this.InnerImage.Width - sizeDiff,
                    this.InnerImage.Height);
            }
            else
            {
                this.Crop(
                    halfDiffSize,
                    0,
                    this.InnerImage.Width,
                    this.InnerImage.Height - sizeDiff);
            }

            this.InnerImage = this.Factory.Resize(new Size(width, height)).Image;

            return this;
        }

        private void ReloadImageIfFactoryIsNotCorrectSet()
        {
            bool isFactoryImageIsSameAsTheInnerImage =
                this.Factory.Image.Width == this.InnerImage.Width &&
                this.Factory.Image.Height == this.InnerImage.Height;
            if (!isFactoryImageIsSameAsTheInnerImage)
            {
                this.Factory.Load(this.InnerImage);
            }
        }

        public void SaveTo(string filename, string subDirectory = null)
        {
            string pathToFile = $"{this.directoryPath}\\{(string.IsNullOrEmpty(subDirectory) ? string.Empty : subDirectory)}";
            this.Factory.Save($"{pathToFile}{filename}");
        }

        public void SaveTo(Image image, string filename, string subDirectory = null)
        {
            string pathToFile = $"{this.directoryPath}\\{(string.IsNullOrEmpty(subDirectory) ? string.Empty : subDirectory)}";
            this.Factory.Load(image).Save($"{pathToFile}{filename}");
        }

        public void Dispose()
        {
            if (this.Factory != null)
            {
                this.Factory.Dispose();
                this.Factory = null;
            }

            GC.SuppressFinalize(this);
        }

        private Image Resize(int width, int height)
        {
            return this.Factory.Resize(new Size(width, height)).Image;
        }

        private bool IsHeightLargerThanWidth()
        {
            return this.InnerImage.Width < this.InnerImage.Height;
        }
    }
}