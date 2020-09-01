using MVVM.DataAccess;
using MVVM.DataAccess.Entities.Models;
using MVVM.DataAccess.Factory;
using MVVM.DesktopGUI.ViewModels.Base;
using MVVM.Utilities;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MVVM.DesktopGUI.ViewModels
{
    public class SupplierViewModel : ViewModelBase
    {
        #region Fields
        // Observable Collection
        private ObservableCollection<Supplier> suppliers;
        // Selected Supplier
        private Supplier selectedSupplier;
        #endregion

        #region Constructors
        // Constructor
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
        /// Loads all suppliers from the database
        /// </summary>
        protected override async Task LoadAllAsync()
        {
            // Create Factory
            RepositoryFactory<SupplierRepository, Supplier> factory =
                new RepositoryFactory<SupplierRepository, Supplier>();

            // Create Repository
            SupplierRepository supplierRepository = factory.Create();

            // Declare variable for storing products
            IEnumerable<Supplier> suppliers = null;

            // Run GetAll on a seperate thread
            await Task.Run(() =>
            {
                // Get all products from the database
                suppliers = supplierRepository.GetAll();
            });

            // Replace Observable Collection
            Suppliers.ReplaceWith(suppliers);
        }
        #endregion
    }
}