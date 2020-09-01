using MVVM.DataAccess;
using MVVM.DataAccess.Entities.Models;
using MVVM.DataAccess.Factory;
using MVVM.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.DesktopGUI.ViewModels
{
    public class SupplierViewModel : INotifyPropertyChanged
    {
        #region Fields
        // Property Changed Event
        public event PropertyChangedEventHandler PropertyChanged;

        // Observable Collection
        private ObservableCollection<Supplier> suppliers;
        // Selected Supplier
        private Supplier selectedSupplier;
        #endregion

        #region Constructors
        public SupplierViewModel() { }
        #endregion

        #region Properties
        /// <summary>
        /// Suppliers displayed in the view
        /// </summary>
        ObservableCollection<Supplier> Suppliers
        {
            get
            {
                return suppliers;
            }
            set
            {
                if(suppliers != value)
                {
                    suppliers = value;

                    // Raise ProperyChanged Event
                    NotifyPropertyChanged(nameof(Suppliers));
                }
            }
        }

        /// <summary>
        /// The selected supplier in the view
        /// </summary>
        public virtual Supplier SelectedSupplier
        {
            get
            {
                return selectedSupplier;
            }
            set
            {
                if(selectedSupplier != value)
                {
                    selectedSupplier = value;

                    // Raise ProperyChanged Event
                    NotifyPropertyChanged(nameof(SelectedSupplier));
                }
            }
        }
        #endregion

        #region Methods
        public virtual void Initialize()
        {
            // Load suppliers
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
            // Replace Observable Collection
            Suppliers.ReplaceWith(suppliers);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // Invoke event, to trigger a view update
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}