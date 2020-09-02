using MVVM.DesktopGUI.ViewModels;

using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        private readonly ProductViewModel productViewModel;
        private bool loaded;

        public ProductsView()
        {
            InitializeComponent();

            productViewModel = DataContext as ProductViewModel;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(!loaded)
            {
                await productViewModel.Initialize();

                loaded = true;
            }
        }
    }
}
