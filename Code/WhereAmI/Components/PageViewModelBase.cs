using Caliburn.Micro;
using WhereAmI.Services;

namespace WhereAmI.Components
{
	public class PageViewModelBase : Screen, IPageViewModel
	{
		protected readonly IUiService UiService;

        protected PageViewModelBase(IUiService uiService)
		{
			UiService = uiService;
		}

		public void GoBack()
		{
            UiService.Navigation.GoBack();
		}

		public bool CanGoBack
		{
		    get
		    {
                return UiService.Navigation.CanGoBack;
		    }
		}
	}
}
