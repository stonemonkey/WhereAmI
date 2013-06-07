using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace WhereAmI.Core.Repository.FileAccess
{
    public class FileManipulator : IFileManipulator
    {
        public async Task MoveFileAsync(StorageFile file, StorageFolder destinationFolder, string desiredNewFileName)
        {
            if (Exist(destinationFolder, desiredNewFileName))
            {
                try
                {
                    StorageFile fileToDelete = await destinationFolder.GetFileAsync(desiredNewFileName);
                    await DeleteAsync(fileToDelete);

                }
                catch (Exception)
                {
                    //TODO there is a known issue of the .net api; fix this when the api will be fixed
                }
            }

            await file.MoveAsync(destinationFolder,desiredNewFileName);
        }

        public async Task MoveFileAsync(StorageFile file, StorageFolder destinationFolder)
        {
           await MoveFileAsync(file, destinationFolder, file.Name);
        }

        public bool Exist(StorageFolder folder, string filePath)
        {
            var errorCode = folder.GetFileAsync(filePath).ErrorCode;
            return errorCode == null
                   || errorCode.GetType() != typeof(FileNotFoundException);
        }

        public async Task DeleteAsync(StorageFile file)
        {
            await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }

    }
}