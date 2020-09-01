using MVVM.DataAccess.Entities.Models;
using MVVM.Entities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM.DesktopGUI.ViewModels.Base
{
    public class ViewModelBase : BindableBase
    {



        #region Methods
        /// <summary>
        /// Initializes <see cref="Suppliers"/>
        /// </summary>
        public virtual void Initialize()
        {
            // Load suppliers
            LoadAll();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void LoadAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}