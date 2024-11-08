using System.ComponentModel;

namespace VACM.NET4_0.Backend.Models
{
  public interface IDeviceModel
  {
    #region Parameters

    int Id { get; set; }
    bool IsDuplex { get; }
    bool IsInput { get; set; }
    bool IsOutput { get; set; }
    bool IsPresent { get; set; }
    event PropertyChangedEventHandler PropertyChanged;
    string ActualId { get; set; }
    string Name { get; set; }

    #endregion
  }
}
