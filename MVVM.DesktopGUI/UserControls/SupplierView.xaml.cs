using MVVM.DesktopGUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.DesktopGUI.UserControls
{
    /// <summary>
    /// Interaction logic for SupplierView.xaml
    /// </summary>
    public partial class SupplierView : UserControl
    {
        private readonly SupplierViewModel supplierViewModel;
        private bool loaded;

        public SupplierView()
        {
            InitializeComponent();

            supplierViewModel = DataContext as SupplierViewModel;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(!loaded)
            {
                await supplierViewModel.Initialize();

                loaded = true;
            }
        }
    }
}