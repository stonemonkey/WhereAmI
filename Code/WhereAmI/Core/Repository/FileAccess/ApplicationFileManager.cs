using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace WhereAmI.Core.Repository.FileAccess
{
    /// <summary>
    /// Define the application file manager.
    /// </summary>
    public class ApplicationFileManager : IApplicationFileManager
    {        
        private readonly StorageFolder _storageFolder;

        public ApplicationFileManager(StorageFolder storageFolder)
        {
            _storageFolder = storageFolder;
        }

        public async Task SaveAsync(string filePath, byte[] content)
        {
            StorageFile file = await GetFileAsync(filePath);

            using (IRandomAccessStream writeStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (DataWriter dataWriter = new DataWriter(writeStream))
                {
                    dataWriter.WriteBytes(content);
                    await dataWriter.StoreAsync();
                    await dataWriter.FlushAsync();
                }
            }
        }

        public async Task<byte[]> LoadAsync(string filePath)
        {
            StorageFile currentStorage = await GetFileAsync(filePath, CreationCollisionOption.OpenIfExists);
            using (IRandomAccessStream readStream = await currentStorage.OpenAsync(FileAccessMode.Read))
            {
                using (DataReader dataReader = new DataReader(readStream))
                {
                    await dataReader.LoadAsync((uint)readStream.Size);
                    return dataReader.GetBytes();
                }
            }
        }

        public bool Exist(string filePath)
        {
            var errorCode = _storageFolder.GetFileAsync(filePath).ErrorCode;

             return errorCode==null 
                    || errorCode.GetType() != typeof(FileNotFoundException);
        }

        private async Task<StorageFile> GetFileAsync(string fileName, CreationCollisionOption creationCollision = CreationCollisionOption.ReplaceExisting)
        {
            return await _storageFolder.CreateFileAsync(fileName, creationCollision);
        }
    }
}