using BridgePattern.Infrastructure.Measures;
using BridgePattern.Modules.Helpers;

namespace BridgePattern.Infrastructure.Devices;

public sealed class SunDevice : Device
{
  public SunDevice(IMeasure measure) : base(measure)
  {

  }

  public override string GetBatteryLevel()
  {
    return $"{NumberHelper.Get100RandomNumber()} % 太陽光";
  }

  public override string GetDeviceName()
  {
    return "太陽光";
  }
}
