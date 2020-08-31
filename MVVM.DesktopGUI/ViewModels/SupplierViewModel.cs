using MVVM.DataAccess;
using MVVM.DataAccess.Entities.Models;
using MVVM.Entities;
using MVVM.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.DesktopGUI.ViewModels
{
    public class SupplierViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Supplier> suppliers;
        private Supplier selectedSupplier;

        public SupplierViewModel()
        {

        }

        public virtual Supplier SelectedSupplier
        {
            get
            {
                return selectedSupplier;
            }
            set
            {
                selectedSupplier = value;
                NotifyPropertyChanged(nameof(SelectedSupplier));
            }
        }

        ObservableCollection<Supplier> Suppliers
        {
            get
            {
                return suppliers;
            }
            set
            {
                suppliers = value;
                NotifyPropertyChanged(nameof(Supplier));
            }
        }

        public virtual void Initialize()
        {
            LoadAllSuppliers();
        }

        public virtual void LoadAllSuppliers()
        {
            // Create Factory
            RepositoryFactory<SupplierRepository, Supplier> factory = new RepositoryFactory<SupplierRepository, Supplier>();
            // Create Repository
            SupplierRepository supplierRepository = factory.Create();
            // Get All
            IEnumerable<Supplier> suppliers = supplierRepository.GetAll();

            Suppliers.ReplaceWith(suppliers);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}