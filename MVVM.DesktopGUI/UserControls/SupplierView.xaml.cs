using MVVM.DesktopGUI.ViewModels;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void OnSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            supplierViewModel.IsEditEnabled = supplierViewModel.SelectedSupplier switch
            {
                null => false,
                _ => true,
            };
            supplierViewModel.IsSaveEnabled = false;
            supplierViewModel.IsTextBoxesReadOnly = true;
            supplierViewModel.IsNewEnabled = true;
        }
    }
}