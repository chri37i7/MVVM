using MVVM.DataAccess.Entities.Models;
using MVVM.Entities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.DesktopGUI.ViewModels.Base
{
    /// <summary>
    /// Base class for ViewModel classes
    /// </summary>
    public class ViewModelBase : BindableBase
    {
        #region Methods
        /// <summary>
        /// Runs the <see cref="LoadAllAsync"/> method
        /// </summary>
        public virtual async Task Initialize()
        {
            // Load suppliers
            await LoadAllAsync();
        }

        /// <summary>
        /// Loads data from the database
        /// </summary>
        protected virtual Task LoadAllAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}