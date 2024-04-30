using BridgePattern.Infrastructure.Measures;
using BridgePattern.Modules.Helpers;

namespace BridgePattern.Infrastructure.Devices;

public sealed class BatteryDevice : Device
{
  public BatteryDevice(IMeasure measure) : base(measure)
  {

  }

  public override string GetBatteryLevel()
  {
    return $"{NumberHelper.Get100RandomNumber()} %";
  }

  public override string GetDeviceName()
  {
    return "バッテリー";
  }
}
