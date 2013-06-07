using System.Threading.Tasks;
using Caliburn.Micro;
using WhereAmI.Core.Model;
using WhereAmI.Core.Repository;

namespace WhereAmI.Results
{
    public class SaveResult : ResultBase
    {
        private readonly Waypoints _waypoints;

        public SaveResult(Waypoints waypoints)
        {
            _waypoints = waypoints;
        }

        public override async void Execute(ActionExecutionContext context)
        {
            var repository = WaypointsRepositoryFactory.Create();
            
            await repository.SaveAsync(_waypoints);

            OnCompleted();
        }
    }
}