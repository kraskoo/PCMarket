namespace PCMarket.Services.Managers
{
    using System;
    using System.Drawing;
    using System.IO;

    public class TemproaryFileManager
    {
        private readonly string baseDirectory;
        public TemproaryFileManager(string assemblyPath)
        {
            var lastSlash = assemblyPath.LastIndexOf("\\", StringComparison.Ordinal);
            assemblyPath = assemblyPath.Substring(0, lastSlash).Replace("\\bin\\Debug", string.Empty);
            lastSlash = assemblyPath.LastIndexOf("\\", StringComparison.Ordinal);
            this.baseDirectory = assemblyPath.Substring(0, lastSlash);
        }

        public string BaseDirectoryContainer => $"{baseDirectory}\\Upload";

        public bool ChechIfFolderExists(string folderPath)
        {
            return Directory.Exists($"{BaseDirectoryContainer}\\{folderPath}");
        }

        public bool ChechIfFileExists(string filePath)
        {
            return File.Exists($"{BaseDirectoryContainer}\\{filePath}");
        }

        public void CreateFolder(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
        }

        public void DeleteFolder(string folderPath)
        {
            Directory.Delete($"{BaseDirectoryContainer}\\{folderPath}");
        }

        public void DeleteFile(string filePath)
        {
            File.Delete($"{BaseDirectoryContainer}\\{filePath}");
        }

        public void UploadFile(string fromPath, string toPath, bool @override = false)
        {
            var file = File.ReadAllBytes(fromPath);
            if (@override)
            {
                this.DeleteFile($"{BaseDirectoryContainer}\\{toPath}");
            }

            File.WriteAllBytes($"{BaseDirectoryContainer}\\{toPath}", file);
        }

        public void UploadFile(byte[] fileBytes, string toPath)
        {
            File.WriteAllBytes(toPath, fileBytes);
        }

        public byte[] GetRetFileBytes(string filePath)
        {
            return File.ReadAllBytes($"{filePath}");
        }

        public Image GetRetFileAsImage(string filePath)
        {
            return Image.FromFile($"{BaseDirectoryContainer}\\{filePath}", true);
        }

        public Image GetRetFileAsImage(Stream stream)
        {
            return Image.FromStream(stream);
        }

        public string GetFilename(string path)
        {
            var lastSlash = path.LastIndexOf("/", StringComparison.Ordinal);
            return path.Substring(lastSlash + 1, path.Length - lastSlash - 1);
        }
    }
}