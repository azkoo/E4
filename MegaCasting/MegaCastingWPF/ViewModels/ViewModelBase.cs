using MegaCasting.DBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingWPF.ViewModels
{
    class ViewModelBase
    {
        #region Attributes

        private MegaCastingEntities _Entities;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définis 
        /// </summary>
        public MegaCastingEntities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ViewModelBase()
        {
            this.Entities = new MegaCastingEntities();
        }

        #endregion
    }
}
