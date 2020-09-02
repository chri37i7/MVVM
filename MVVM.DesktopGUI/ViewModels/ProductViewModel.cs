using MVVM.DataAccess.Base;
using MVVM.DataAccess.Entities.Models;
using MVVM.DataAccess.Factory;
using MVVM.DesktopGUI.ViewModels.Base;
using MVVM.Utilities;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MVVM.DesktopGUI.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        #region Fields
        // Observable Collection
        private ObservableCollection<Product> products;
        // Selected Product
        private Product selectedProduct;
        #endregion

        #region Constructors
        // Constructor
        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Suppliers displayed in the view
        /// </summary>
        public virtual ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                if(products != value)
                {
                    products = value;

                }
            }
        }

        /// <summary>
        /// The selected supplier in the view
        /// </summary>
        public virtual Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                if(selectedProduct != value)
                {
                    selectedProduct = value;

                    // Raise ProperyChanged Event
                    OnPropertyChanged(nameof(SelectedProduct));
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
            RepositoryFactory<RepositoryBase<Product>, Product> factory =
                new RepositoryFactory<RepositoryBase<Product>, Product>();

            // Create Repository
            RepositoryBase<Product> productRepository = factory.Create();

            // Get all products from the database
            IEnumerable<Product> products = await productRepository.GetAllAsync();

            // Replace Observable Collection
            Products.ReplaceWith(products);
        }
        #endregion
    }
}