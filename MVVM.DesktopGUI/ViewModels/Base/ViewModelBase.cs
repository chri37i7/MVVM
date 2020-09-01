using MVVM.DataAccess.Entities.Models;
using MVVM.Entities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVM.DesktopGUI.ViewModels.Base
{
    /// <summary>
    /// Base class for ViewModel classes
    /// </summary>
    public class ViewModelBase : BindableBase
    {
        #region Methods
        /// <summary>
        /// Runs the <see cref="LoadAll"/> method
        /// </summary>
        public virtual void Initialize()
        {
            // Load suppliers
            LoadAll();
        }

        /// <summary>
        /// Loads data from the database
        /// </summary>
        protected virtual void LoadAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}