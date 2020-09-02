using MVVM.DataAccess;
using MVVM.DataAccess.Entities.Models;
using MVVM.DataAccess.Factory;
using MVVM.DesktopGUI.ViewModels.Base;
using MVVM.Entities;
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
        // Bool's for boxes, hehe
        private bool isTextBoxesReadOnly;
        private bool isNewEnabled;
        private bool isEditEnabled;
        private bool isSaveEnabled;

        #endregion

        #region Constructors
        // Constructor
        public SupplierViewModel()
        {
            // Initialize Commands
            NewSupplierCommand = new CommandBase<string>(NewSupplier);
            EditSupplierCommand = new CommandBase<string>(EditSupplier);
            SaveSupplierCommand = new CommandBase<string>(SaveSupplier);

            // Initialize suppliers
            suppliers = new ObservableCollection<Supplier>();

            // Initialize textboxes state field
            isTextBoxesReadOnly = true;
            // Initialize button state fields
            isNewEnabled = true;
            isEditEnabled = true;
            isSaveEnabled = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Suppliers displayed in the view
        /// </summary>
        public virtual ObservableCollection<Supplier> Suppliers
        { get { return suppliers; } set { SetProperty(ref suppliers, value); } }

        /// <summary>
        /// Selected supplier in the view
        /// </summary>
        public virtual Supplier SelectedSupplier
        { get { return selectedSupplier; } set { SetProperty(ref selectedSupplier, value); } }

        /// <summary>
        /// Used for controlling the textboxes readonly state
        /// </summary>
        public virtual bool IsTextBoxesReadOnly
        { get { return isTextBoxesReadOnly; } set { SetProperty(ref isTextBoxesReadOnly, value); } }

        /// <summary>
        /// Used for controlling the edit buttons enabled state
        /// </summary>
        public virtual bool IsNewEnabled
        { get { return isNewEnabled; } set { SetProperty(ref isNewEnabled, value); } }

        /// <summary>
        /// Used for controlling the edit buttons enabled state
        /// </summary>
        public virtual bool IsEditEnabled
        { get { return isEditEnabled; } set { SetProperty(ref isEditEnabled, value); } }

        /// <summary>
        /// Used for controlling the save buttons enabled state
        /// </summary>
        public virtual bool IsSaveEnabled
        { get { return isSaveEnabled; } set { SetProperty(ref isSaveEnabled, value); } }

        /// <summary>
        /// 
        /// </summary>
        public CommandBase<string> NewSupplierCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public CommandBase<string> EditSupplierCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public CommandBase<string> SaveSupplierCommand { get; private set; }
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
            IsNewEnabled = false;
            IsEditEnabled = false;
            IsSaveEnabled = true;

            IsTextBoxesReadOnly = false;
        }

        public virtual void NewSupplier(string supplier)
        {
            SelectedSupplier = null;

            IsNewEnabled = false;
            IsEditEnabled = false;
            IsSaveEnabled = true;

            IsTextBoxesReadOnly = false;
        }

        public virtual void SaveSupplier(string fixme)
        {
            if(SelectedSupplier is null)
            {
                Supplier supplier = new Supplier()
                {

                };

                Suppliers.Add(supplier);
            }
        }
        #endregion
    }
}