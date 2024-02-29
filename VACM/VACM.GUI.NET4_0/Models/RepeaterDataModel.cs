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

        /// <summary>
        /// Adds a dictionary to the repeater data model, if it does not already exist.
        /// </summary>
        /// <param name="firstDeviceControl">The first device control</param>
        /// <param name="secondDeviceControl">The second device control</param>
        public void AddDictionary
            (DeviceControl firstDeviceControl, DeviceControl secondDeviceControl)
        {
            AddThisDictionary(firstDeviceControl, secondDeviceControl);
            AddThisDictionary(secondDeviceControl, firstDeviceControl);
        }

        /// <summary>
        /// Adds a repeater to the repeater data model, if it does not already exist.
        /// </summary>
        /// <param name="firstDeviceControl">The first device control</param>
        /// <param name="secondDeviceControl">The second device control</param>
        public void AddThisDictionary
            (DeviceControl inputDeviceControl, DeviceControl outputDeviceControl)
        {
            if (inputDeviceControl is null || outputDeviceControl is null
                || (RepeaterData.ContainsKey(inputDeviceControl)
                    && RepeaterData[inputDeviceControl]
                        .ContainsKey(outputDeviceControl)))
            {
                return;
            }

            RepeaterData.Add(inputDeviceControl,
                GetDictionary(inputDeviceControl, outputDeviceControl));
        }

        /// <summary>
        /// Return a valid dictionary object.
        /// </summary>
        /// <param name="firstDeviceControl">The first device control</param>
        /// <param name="secondDeviceControl">The second device control</param>
        /// <returns>The dictionary object</returns>
        internal Dictionary<DeviceControl, RepeaterModel> GetDictionary
            (DeviceControl firstDeviceControl, DeviceControl secondDeviceControl)
        {
            return new Dictionary<DeviceControl, RepeaterModel>
            {
                {
                    secondDeviceControl,
                    new RepeaterModel(firstDeviceControl, secondDeviceControl)
                },
            };
        }

        #endregion
    }
}
