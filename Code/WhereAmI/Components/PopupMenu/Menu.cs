using System.Windows.Input;
using Caliburn.Micro;
using Action = System.Action;

namespace WhereAmI.Components.PopupMenu
{
    public class Menu : PropertyChangedBase
    {
        public string Name { get; set; }

        public ICommand Command { get; set; }

        public Menu(string name, Action action)
        {
            Name = name;
            Command = new RelayCommand(action);
        }
    }
}
