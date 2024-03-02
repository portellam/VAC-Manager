namespace VACM.NET4_0.Extensions.PropertyValueChanged
{
    public class PropertyValueChangedEventArgs : System.EventArgs
    {
        #region Parameters

        private string propertyValue;

        public string PropertyValue
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
        public PropertyValueChangedEventArgs(string propertyValue)
        {
            this.propertyValue = propertyValue;
        }

        #endregion
    }
}