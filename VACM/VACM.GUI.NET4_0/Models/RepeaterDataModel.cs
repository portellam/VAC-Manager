using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VACM.GUI.NET4_0.ViewModels;

namespace VACM.GUI.NET4_0.Models
{
    public class RepeaterDataModel
    {
        #region Parameters

        public Dictionary<DeviceControl, Dictionary<DeviceControl, RepeaterModel>>
            RepeaterData
        { get; private set; }

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public RepeaterDataModel()
        {
            RepeaterData = new Dictionary<DeviceControl,
                Dictionary<DeviceControl, RepeaterModel>>();
        }

        #endregion
    }
}
