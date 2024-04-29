using BridgePattern.Modules.Helpers;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.Devices;

public abstract class Device
{
  private Random _random = new Random();
  public abstract string GetName();
  public abstract string GetMeasure();


  public string GetSensitivity()
  {
    Sensitivity sensitivity = new Sensitivity(NumberHelper.Get100RandomNumber().ToString());
    return sensitivity.DisplayValue;
  }
}
