using System;
using System.Threading.Tasks;
using WhereAmI.Core.Extensions;
using WhereAmI.Core.Repository.FileAccess;
using WhereAmI.Core.Repository.Serializer;

namespace WhereAmI.Core.Repository
{
    /// <summary>
    /// The base file persistor. This persistor is used to persist an object as a file.
    /// </summary>
    public abstract class FileRepositoryBase<TEntity>
        : IRepository<TEntity>
    {
        private readonly string _fileName;
        private readonly ISerializeController _serializeController;
        private readonly IFileManager _fileManager;

        public FileRepositoryBase(ISerializeController serializeController, IFileManager fileManager)
        {
            _fileName = typeof(TEntity).ToGenericTypeString();
            _serializeController = serializeController;
            _fileManager = fileManager;
        }

        public virtual async Task SaveAsync(TEntity obj)
        {
            byte[] serializeObj = _serializeController.Serialize(obj);
            await _fileManager.SaveAsync(_fileName, serializeObj);
        }

        public virtual async Task<TEntity> LoadAsync()
        {
            byte[] serializeObj = await _fileManager.LoadAsync(_fileName);
            if (serializeObj.Length == 0)
            {
                return default(TEntity);
            }
            return _serializeController.Deserialize<TEntity>(serializeObj);
        }

        public virtual bool IsSaved()
        {
            try
            {
                //TODO: Replace - In the current version of .NET 4.5 we don't have a method to check if a file exist or not.
                TEntity file = default(TEntity);
                Task.Run(() => file = LoadAsync().Result).Wait();
                if (file == null)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //TODO: Log information
                return false;
            }

            return true;

        }
    }
}