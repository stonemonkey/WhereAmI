using System;

namespace WhereAmI.Core.Repository.Serializer.Encoder
{
    /// <summary>
    /// Define the interface use to encode/decode data.
    /// </summary>
    public interface IEncoder
    {
        System.Text.Encoding Current { get; }
        string ToString(Byte[] content);
        Byte[] ToArray(string content);
    }
}