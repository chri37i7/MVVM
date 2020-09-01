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
        public SupplierViewModel()
        {
            Suppliers = new ObservableCollection<Supplier>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Suppliers displayed in the view
        /// </summary>
        public virtual ObservableCollection<Supplier> Suppliers
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
                    OnPropertyChanged(nameof(SelectedSupplier));
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes <see cref="Suppliers"/>
        /// </summary>
        public virtual void Initialize()
        {
            // Load suppliers
            LoadAllSuppliers();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void LoadAllSuppliers()
        {
            // Create Factory
            RepositoryFactory<SupplierRepository, Supplier> factory = 
                new RepositoryFactory<SupplierRepository, Supplier>();

            // Create Repository
            SupplierRepository supplierRepository = factory.Create();
            // Get All
            IEnumerable<Supplier> suppliers = supplierRepository.GetAll();

            // Replace Observable Collection
            Suppliers.ReplaceWith(suppliers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}