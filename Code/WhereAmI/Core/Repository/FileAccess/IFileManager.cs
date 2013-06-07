using System.Threading.Tasks;

namespace WhereAmI.Core.Repository.FileAccess
{
    /// <summary>
    /// Define the interface used to access the files.
    /// </summary>
    public interface IFileManager
    {
        Task SaveAsync(string filePath, byte[] content);
        Task<byte[]> LoadAsync(string filePath);

        /// <summary>
        /// Check if a file exist.
        /// </summary>
        bool Exist(string filePath);
    }
}