using Caliburn.Micro;
using WhereAmI.Results;

namespace WhereAmI.Services
{
    public class UiService : IUiService
    {
        public INavigationService Navigation { get; private set; }

        public UiService(INavigationService navigation)
        {
            Navigation = navigation;
        }

        public OpenChildResult<TChild> ShowChild<TChild>() where TChild : IScreen
        {
            return new OpenChildResult<TChild>();
        }

        public OpenChildResult<TChild> ShowChild<TChild>(TChild child) where TChild : IScreen
        {
            return new OpenChildResult<TChild>(child);
        }

        public IResult ShowMessageBox(string title, string message)
        {
            return new MessageDialogResult(message, title);
        }
    }
}