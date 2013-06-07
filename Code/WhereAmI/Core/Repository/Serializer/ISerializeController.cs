namespace WhereAmI.Core.Repository.Serializer
{
    /// <summary>
    /// Define the interface use to serialize/deserilize an object.
    /// </summary>
    public interface ISerializeController
    {
        byte[] Serialize(object obj);
        TEntity Deserialize<TEntity>(byte[] content);
    }
}