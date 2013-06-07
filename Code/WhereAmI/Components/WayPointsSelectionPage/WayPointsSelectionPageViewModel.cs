using WhereAmI.Services;

namespace WhereAmI.Components.WayPointsSelectionPage
{
	public class WayPointsSelectionPageViewModel : PageViewModelBase
	{
        public WayPointsSelectionPageViewModel(IUiService uiService)
			: base(uiService)
        {
            DisplayName = "Waypoint Selection";
        }
    }
}
