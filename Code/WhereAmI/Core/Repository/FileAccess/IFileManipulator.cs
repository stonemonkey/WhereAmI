using System.Threading.Tasks;
using Windows.Storage;

namespace WhereAmI.Core.Repository.FileAccess
{
    /// <summary>
    /// Define the interface used to manipulate files.
    /// </summary>
    public interface IFileManipulator
    {
        Task MoveFileAsync(StorageFile file, StorageFolder destinationFolder, string desiredNewFileName);
        Task MoveFileAsync(StorageFile file, StorageFolder destinationFolder);
        bool Exist(StorageFolder folder, string filePath);
        Task DeleteAsync(StorageFile file);
    }
}