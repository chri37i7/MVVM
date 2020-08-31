using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.DesktopGUI.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ProductViewModel()
        {

        }

        public void Initialize()
        {

        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}