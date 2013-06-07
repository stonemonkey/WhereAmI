using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using WhereAmI.Core.Model;
using WhereAmI.Core.Repository;

namespace WhereAmI.Tests.Core
{
    [TestClass]
    public class WaypointsRepositoryTests
    {
        [TestMethod]
        public void Save_CheckIfTheItemsArePersist_ResultTheSameTripCollection()
        {
            WaypointsRepository repository = WaypointsRepositoryFactory.Create();

            Waypoints waypoints = new Waypoints();
            waypoints.Add(CreateWaypoint());

            Task.Run(() => repository.SaveAsync(waypoints)).Wait();

            Waypoints savedWaypoints = null;
            Task.Run(() => savedWaypoints = repository.LoadAsync().Result).Wait();

            Assert.AreEqual(1, savedWaypoints.Count);
            Assert.IsNotNull(savedWaypoints[0].Position);

        }

        private Waypoint CreateWaypoint()
        {
            return new Waypoint()
            {
                Description = "bla bla bla",
                Position = new GPSPosition()
                                                                                          {
                                                                                              Altitude = 123.1,
                                                                                              Longitude = 1,
                                                                                              Latitude = 1
                                                                                          },
            };
        }
    }
}
