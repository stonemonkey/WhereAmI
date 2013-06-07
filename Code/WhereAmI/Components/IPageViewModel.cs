namespace WhereAmI.Components
{
    public interface IPageViewModel
    {
        void GoBack();

        bool CanGoBack { get; }
    }
}