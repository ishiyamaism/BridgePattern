using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.Infrastructure.Devices;

public sealed class ACDevice : Device
{
  public ACDevice(IMeasure measure) : base(measure)
  {
  }

  public override string GetBatteryLevel()
  {
    return "--";
  }

  public override string GetDeviceName()
  {
    return "電源";
  }
}
