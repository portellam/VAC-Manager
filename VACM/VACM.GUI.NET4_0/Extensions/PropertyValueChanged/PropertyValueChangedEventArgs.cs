﻿namespace VACM.GUI.NET4_0.Extensions.PropertyValueChanged
{
    public class PropertyValueChangedEventArgs : System.EventArgs
    {
        #region Parameters

        private object propertyValue;

        public object PropertyValue
        {
            get
            {
                return propertyValue;
            }
        }

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyValue">The property value</param>
        public PropertyValueChangedEventArgs(object propertyValue)
        {
            this.propertyValue = propertyValue;
        }

        #endregion
    }
}