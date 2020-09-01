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

        private ProductViewModel productViewModel = new ProductViewModel();

        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public CommandBase<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {

            //switch(destination)
            //{
            //    case "supplier":
            //        CurrentViewModel = supplierViewModel;
            //        break;
            //    case "product":
            //    default:
            //        CurrentViewModel = productViewModel;
            //        break;
            //}
        }
    }
}
