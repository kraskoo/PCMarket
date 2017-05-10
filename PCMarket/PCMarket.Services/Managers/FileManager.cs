using System.IO;

namespace PCMarket.Services.Managers
{
    using System;
    using System.Data.Entity.SqlServer.Utilities;
    using System.Linq;
    using Dropbox.Api.Files;
    using Features;

    public class FileManager
    {
        private readonly DropboxClientService dropboxClientService;

        public FileManager(DropboxClientService dropboxClientService)
        {
            this.dropboxClientService = dropboxClientService;
        }

        public FileManager()
        {
            this.dropboxClientService = new DropboxClientService();
        }

        public bool CheckIfDirectoryExists(string path)
        {
            var folderArgs = new ListFolderArg(path);
            var folders = this.dropboxClientService.Files.ListFolderAsync(folderArgs);
            try
            {
                var folderResults = folders.Result;
                return folderResults.Entries.Any(f => f.IsFile && f.Name == path);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckIfFileExists(string pathfile)
        {
            var folderArgs = new ListFolderArg(pathfile);
            var folders = this.dropboxClientService.Files.ListFolderAsync(folderArgs);
            try
            {
                var folderResults = folders.Result;
                return folderResults.Entries.Any(f => f.IsFile && f.Name == pathfile);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public FolderMetadata CreateFolder(string folderpath)
        {
            FolderMetadata folder;
            try
            {
                folder = this.dropboxClientService
                    .Files
                    .CreateFolderAsync(folderpath)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception)
            {
                folder = default(FolderMetadata);
            }

            return folder;
        }

        public bool DeleteFolder(string folderpath)
        {
            try
            {
                this.dropboxClientService
                    .Files
                    .DeleteAsync(new DeleteArg(folderpath))
                    .GetAwaiter()
                    .GetResult();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public FileMetadata SaveToFile(string dropboxFromPath, string file)
        {
            FileMetadata uploadTask;
            try
            {
                using (var fileStream = new FileStream($"{dropboxFromPath}/{file}", FileMode.CreateNew))
                {
                    uploadTask = this.dropboxClientService.Files
                        .UploadSessionFinishAsync(
                            new UploadSessionFinishArg(
                                new UploadSessionCursor(),
                                new CommitInfo(file)),
                            fileStream)
                        .WithCurrentCulture()
                        .GetResult();
                }
                
            }
            catch (Exception)
            {
                uploadTask = default(FileMetadata);
            }

            return uploadTask;
        }
    }
}