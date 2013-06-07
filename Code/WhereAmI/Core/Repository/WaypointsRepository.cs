using System.Linq;
using System.Threading.Tasks;
using WhereAmI.Core.Model;
using WhereAmI.Core.Repository.FileAccess;
using WhereAmI.Core.Repository.Serializer;

namespace WhereAmI.Core.Repository
{
    public class WaypointsRepository : FileRepositoryBase<Waypoints>
    {
        public WaypointsRepository(ISerializeController serializeController, IFileManager fileManager)
            : base(serializeController, fileManager)
        {
        }

        public override async Task<Waypoints> LoadAsync()
        {
            Waypoints trips = await base.LoadAsync();
            if (trips == null)
            {
                return new Waypoints();
            }

            return trips;
        }

        public override async Task SaveAsync(Waypoints waypoints)
        {
            foreach (Waypoint waypoint in waypoints)
            {
                if (waypoint.Id == 0)
                {
                    // Generate a new 
                    int newId = waypoints.Max(x => x.Id);
                    waypoint.Id = newId + 1;
                }
            }

            await base.SaveAsync(waypoints);
        }
    }
}
