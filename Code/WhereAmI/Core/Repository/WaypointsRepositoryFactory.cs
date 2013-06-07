using System.Text;
using WhereAmI.Core.Repository.FileAccess;
using WhereAmI.Core.Repository.Serializer;
using Encoder = WhereAmI.Core.Repository.Serializer.Encoder.Encoder;

namespace WhereAmI.Core.Repository
{
    public static class WaypointsRepositoryFactory
    {
        public static WaypointsRepository Create()
        {
            return new WaypointsRepository(
                (new SerializeController(new Encoder(Encoding.Unicode))),
                new ApplicationFileManager((Windows.Storage.ApplicationData.Current.LocalFolder)));

        }
    }
}