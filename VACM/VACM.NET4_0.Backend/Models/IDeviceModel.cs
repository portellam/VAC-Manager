namespace VACM.NET4_0.Backend.Models
{
  public interface IDeviceModel
  {
    string Id { get; set; }
    string Name { get; set; }
    bool IsInput { get; set; }
    bool IsOutput { get; set; }
    bool IsPresent { get; set; }
  }
}
