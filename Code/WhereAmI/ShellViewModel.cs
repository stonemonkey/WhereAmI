using Caliburn.Micro;
using WhereAmI.Components.MainPage;
using WhereAmI.Results;

namespace WhereAmI
{
	public class ShellViewModel : Conductor<Screen>, IShellViewModel
	{      
        protected override void OnInitialize()
        {
            base.OnInitialize();

            var result = new OpenChildResult<MainPageViewModel>();
            result.Execute(new ActionExecutionContext { Target = this });
        }
    }
}
