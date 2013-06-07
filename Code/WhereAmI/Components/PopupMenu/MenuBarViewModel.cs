using Caliburn.Micro;

namespace WhereAmI.Components.PopupMenu
{
    public class MenuBarViewModel : Screen
    {
        public MenuCollection Menus { get; set; }

        public MenuBarViewModel()
        {
            Menus = new MenuCollection();
        }
    }
}