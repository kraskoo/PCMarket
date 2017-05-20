namespace PCMarket.Services.ImageWorker
{
    using System.Drawing;

    public interface IFluentManager
    {
        ImageManager Load(string filepath);

        ImageManager MiddlewareReload(Image image);

        ImageManager AsPng();

        ImageManager AsTiff();

        ImageManager AsBitmap();

        ImageManager AsGif();

        ImageManager AsJpeg();

        ImageManager Crop(int x, int y, int width, int height);

        ImageManager GetRectangled();

        ImageManager GetRectangled(int width, int height);

        void SaveTo(string filename, string subDirectory = null);
    }
}