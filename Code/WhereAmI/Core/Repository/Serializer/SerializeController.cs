using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using WhereAmI.Core.Repository.Serializer.Encoder;

namespace WhereAmI.Core.Repository.Serializer
{
    /// <summary>
    /// Control the serialization of an object.
    /// </summary>
    public class SerializeController : ISerializeController
    {
        private readonly IEncoder _encoder;

        public SerializeController(IEncoder encoder)
        {
            _encoder = encoder;
        }

        public byte[] Serialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractSerializer serializer = GetSerializer(obj.GetType());
                using (StreamWriter streamWriter = new StreamWriter(stream, _encoder.Current))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter))
                    {
                        serializer.WriteObject(xmlWriter, obj);
                        xmlWriter.Flush();
                    }

                    streamWriter.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        return _encoder.ToArray(streamReader.ReadToEnd());
                    }
                }
            }
        }

        public TEntity Deserialize<TEntity>(byte[] content)
        {
            using (StringReader reader = new StringReader(_encoder.ToString(content)))
            {
                XmlReader xmlReader = XmlReader.Create(reader);
                DataContractSerializer serializer = GetSerializer(typeof(TEntity));

                return (TEntity)serializer.ReadObject(xmlReader);
            }
        }

        private DataContractSerializer GetSerializer(Type objType)
        {
            return new DataContractSerializer(objType);
        }
    }
}