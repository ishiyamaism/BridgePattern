using BridgePattern.Modules.Helpers;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.Devices;

public abstract class Device
{
  public abstract string GetName();
  public abstract string GetMeasure();
  public abstract string GetBatteryLevel();

  public string GetSensitivity()
  {
    Sensitivity sensitivity = new Sensitivity(NumberHelper.Get100RandomNumberString());
    return sensitivity.DisplayValue;
  }
}
