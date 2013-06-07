using System.Threading.Tasks;

namespace WhereAmI.Core.Repository
{
    /// <summary>
    /// Define the interface used to persist an object
    /// </summary>
    public interface IRepository<TEntity>
    {
        Task SaveAsync(TEntity obj);
        Task<TEntity> LoadAsync();

        /// <summary>
        /// Check if the given items were already saved.
        /// </summary>
        /// <returns></returns>
        bool IsSaved();
    }
}