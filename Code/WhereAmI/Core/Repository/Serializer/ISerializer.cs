namespace WhereAmI.Core.Repository.Serializer
{
    /// <summary>
    /// Define interface used to serialize entities.
    /// </summary>
    public interface ISerializer<in TEntity>
        where TEntity : class
    {
        string Serialize(TEntity entity);
    }
}