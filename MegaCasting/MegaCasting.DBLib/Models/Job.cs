using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.DBLib
{
   public partial class Job
    {
        #region Attributes

        public Job _ShowJob;

        #endregion

        #region Methods

        /// <summary>
        /// Retourne le nom du métier ainsi que son type de métier
        /// </summary>
        public string ShowJob
        {
            get { return this.Name + " - " + this.JobType.Name; }
        }

        #endregion
    }
}
