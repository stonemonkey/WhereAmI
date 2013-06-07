using System.Collections.Generic;
using Windows.Storage.Streams;

namespace WhereAmI.Core.Repository.FileAccess
{
    public static class DataReaderExtension
    {
        private const int BufferSize = 100000;

        public static byte[] GetBytes(this DataReader dataReader)
        {
            List<byte> bytes = new List<byte>();
            while (dataReader.UnconsumedBufferLength > 0)
            {
                byte[] readBytes = new byte[GetBufferSize(dataReader.UnconsumedBufferLength)];
                dataReader.ReadBytes(readBytes);
                bytes.AddRange(readBytes);
            }

            return bytes.ToArray();
        }

        private static uint GetBufferSize(uint bufferSize)
        {
            return BufferSize < bufferSize
                       ? BufferSize
                       : bufferSize;
        }
    }
}