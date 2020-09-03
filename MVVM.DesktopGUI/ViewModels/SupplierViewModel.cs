using Microsoft.Extensions.Logging;

using MVVM.DataAccess;
using MVVM.DataAccess.Entities.Models;
using MVVM.DataAccess.Factory;
using MVVM.DesktopGUI.ViewModels.Base;
using MVVM.Entities;
using MVVM.Utilities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        // Edit mode
        private bool editMode;
        private bool isReadOnly = true;
        #endregion

        #region Constructors
        // Constructor
        public SupplierViewModel()
        {
            // Initialize Commands
            NewCommand = new CommandBase<string>(NewSupplier);
            EditCommand = new CommandBase<string>(EditSupplier);
            SaveCommand = new MyICommand(OnSave, CanSave);

            // Initialize suppliers
            suppliers = new ObservableCollection<Supplier>();
        }
        #endregion

        #region Properties

        #region Suppliers & SelectedSupplier
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
                SetProperty(ref suppliers, value);
            }
        }

        /// <summary>
        /// Selected supplier in the view
        /// </summary>
        public virtual Supplier SelectedSupplier
        {
            get
            {
                return selectedSupplier;
            }
            set
            {
                SetProperty(ref selectedSupplier, value);



                SaveCommand.RaiseCanExecuteChanged();


            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public virtual bool EditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                SetProperty(ref editMode, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                SetProperty(ref isReadOnly, value);
            }
        }

        #region Commands
        /// <summary>
        /// 
        /// </summary>
        public virtual CommandBase<string> NewCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CommandBase<string> EditCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual MyICommand SaveCommand { get; private set; }
        #endregion

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

            // Get all products from the database
            IEnumerable<Supplier> suppliers = await supplierRepository.GetAllAsync();

            // Replace Observable Collection
            Suppliers.ReplaceWith(suppliers);
        }

        public virtual void EditSupplier(string supplier)
        {

        }

        public virtual void NewSupplier(string supplier)
        {
            SelectedSupplier = new Supplier();


        }

        public virtual void SaveSupplier(string fixme)
        {
            if(SelectedSupplier.SupplierId <= 0)
            {
                Supplier supplier = new Supplier()
                {

                };

                Suppliers.Add(supplier);
            }
        }
        #endregion

        public event Action Done = delegate { };

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            // Create Factory
            RepositoryFactory<SupplierRepository, Supplier> factory =
                new RepositoryFactory<SupplierRepository, Supplier>();

            // Create Repository
            SupplierRepository supplierRepository = factory.Create();

            if(!EditMode)
            {
                supplierRepository.Update();
            }
            else
            {
                supplierRepository.Add(SelectedSupplier);
            }

            Done();
        }

        private bool CanSave()
        {
            if(selectedSupplier != null)
            {
                return !selectedSupplier.HasErrors;
            }
            return false;
        }
    }
}