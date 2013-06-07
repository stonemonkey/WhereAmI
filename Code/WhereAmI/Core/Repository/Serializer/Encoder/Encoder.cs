using System;

namespace WhereAmI.Core.Repository.Serializer.Encoder
{
    /// <summary>
    /// Define the encoder used to encode content.
    /// </summary>
    public class Encoder : IEncoder
    {
        public Encoder(System.Text.Encoding encoding)
        {
            Current = encoding;
        }

        public System.Text.Encoding Current { get; private set; }

        public string ToString(Byte[] content)
        {
            return Current.GetString(content, 0, content.Length);
        }

        public Byte[] ToArray(string content)
        {
            return Current.GetBytes(content);
        }
    }
}