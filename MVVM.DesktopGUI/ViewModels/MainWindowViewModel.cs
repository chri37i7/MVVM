using MVVM.DataAccess.Entities;
using MVVM.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.DesktopGUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields
        private readonly SupplierViewModel supplierViewModel;
        private readonly ProductViewModel productViewModel;
        private BindableBase currentViewModel;
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            // Initialize ViewModels
            supplierViewModel = new SupplierViewModel();
            productViewModel = new ProductViewModel();

            // Initialize Command
            NavCommand = new CommandBase<string>(OnNav);
        }
        #endregion

        #region Properties
        /// <summary>
        /// The currently displayer ViewModel
        /// </summary>
        public virtual BindableBase CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        /// <summary>
        /// Command to navigate between ViewModels
        /// </summary>
        public virtual CommandBase<string> NavCommand { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Navigation Method used by <see cref="NavCommand"/>
        /// </summary>
        /// <param name="destination"></param>
        private void OnNav(string destination)
        {
            switch(destination)
            {
                case "suppliers":
                    CurrentViewModel = supplierViewModel;
                    break;
                case "products":
                    CurrentViewModel = productViewModel;
                    break;
            }
        } 
        #endregion
    }
}