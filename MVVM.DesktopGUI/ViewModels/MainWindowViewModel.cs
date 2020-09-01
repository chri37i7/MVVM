using MVVM.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.DesktopGUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            NavCommand = new CommandBase<string>(OnNav);
        }

        private SupplierViewModel supplierViewModel = new SupplierViewModel();

        private ProductViewModel productViewModel= new ProductViewModel();

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public CommandBase<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {

            switch(destination)
            {
                case "suppliers":
                    CurrentViewModel = supplierViewModel;
                    break;
                case "products":
                default:
                    CurrentViewModel = productViewModel;
                    break;
            }
        }
    }
}
