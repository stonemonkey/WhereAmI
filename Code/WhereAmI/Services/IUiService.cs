using Caliburn.Micro;
using WhereAmI.Results;

namespace WhereAmI.Services
{
    public interface IUiService
    {
        INavigationService Navigation { get; }

        OpenChildResult<TChild> ShowChild<TChild>() where TChild : IScreen;

        OpenChildResult<TChild> ShowChild<TChild>(TChild child) where TChild : IScreen;

        IResult ShowMessageBox(string title, string message);
    }
}