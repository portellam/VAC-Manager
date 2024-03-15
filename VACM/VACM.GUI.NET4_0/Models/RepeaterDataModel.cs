﻿using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.Linq;
using VACM.GUI.NET4_0.ViewModels;

namespace VACM.GUI.NET4_0.Models
{
    public class RepeaterDataModel
    {
        //TODO: validate user control validation works as intended!

        #region Parameters

        public Dictionary<DeviceControl, Dictionary<DeviceControl, RepeaterModel>>
            RepeaterData
        { get; private set; }

        public List<MMDevice> LinkWaveInMMDeviceList
        {
            get
            {
                return GetLinkMMDeviceList(DataFlow.Capture);
            }
        }

        public List<MMDevice> LinkWaveOutMMDeviceList
        {
            get
            {
                return GetLinkMMDeviceList(DataFlow.Render);
            }
        }

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

        /// <summary>
        /// Get the linked MMDevice list, given the data flow.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <returns>The linked MMDevice list</returns>
        internal List<MMDevice> GetLinkMMDeviceList(DataFlow dataFlow)
        {
            return RepeaterData.Keys
                .Where(x => x.MMDevice.DataFlow == dataFlow)
                .Select(x => x.MMDevice).Distinct().ToList();
        }

        /// <summary>
        /// Remove a repeater from the repeater data model,
        /// if it does not already exist.
        /// </summary>
        /// <param name="firstDeviceControl">The first device control</param>
        /// <param name="secondDeviceControl">The second device control</param>
        public void RemoveDictionary
            (DeviceControl firstDeviceControl, DeviceControl secondDeviceControl)
        {
            RemoveThisDictionary(firstDeviceControl, secondDeviceControl);
            RemoveThisDictionary(secondDeviceControl, firstDeviceControl);
        }

        /// <summary>
        /// Remove a dictionary from the repeater data model,
        /// if it does not already exist.
        /// </summary>
        /// <param name="firstDeviceControl">The first device control</param>
        /// <param name="secondDeviceControl">The second device control</param>
        internal void RemoveThisDictionary
            (DeviceControl firstDeviceControl, DeviceControl secondDeviceControl)
        {
            if (firstDeviceControl is null || secondDeviceControl is null)
            {
                return;
            }

            if (!DoesRepeaterDataValueContainKey
                (firstDeviceControl, secondDeviceControl))
            {
                return;
            }

            RepeaterData[firstDeviceControl].Remove(secondDeviceControl);
        }

        /// <summary>
        /// Does dictionary contain key.
        /// </summary>
        /// <param name="deviceControl">The device control</param>
        /// <returns>True/False</returns>
        internal bool DoesRepeaterDataContainKey(DeviceControl deviceControl)
        {
            if (deviceControl is null)
            {
                return false;
            }

            return RepeaterData.Keys.Select(x => x.MMDevice == deviceControl.MMDevice)
                .FirstOrDefault();
        }

        /// <summary>
        /// Does dictionary contain value.
        /// </summary>
        /// <param name="firstDeviceControl">The first device control</param>
        /// <param name="secondDeviceControl">The second device control</param>
        /// <returns>True/False</returns>
        internal bool DoesRepeaterDataValueContainKey
            (DeviceControl firstDeviceControl, DeviceControl secondDeviceControl)
        {
            if (secondDeviceControl is null
                || DoesRepeaterDataContainKey(firstDeviceControl))
            {
                return false;
            }

            return RepeaterData.Values
                .Select(thisFirstDeviceControl => thisFirstDeviceControl.Keys
                    .Select(thisSecondDeviceControl =>
                        thisSecondDeviceControl.MMDevice == firstDeviceControl.MMDevice)
                    .FirstOrDefault()).FirstOrDefault();
        }

        #endregion
    }
}