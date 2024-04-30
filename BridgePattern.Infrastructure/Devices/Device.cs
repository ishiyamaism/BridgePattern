using BridgePattern.Infrastructure.Measures;
using BridgePattern.Modules.Helpers;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.Devices;

public abstract class Device
{
  // 切り出した実装単位のインターフェースを持つ
  // DI
  private IMeasure _measure;
  public Device(IMeasure measure)
  {
    _measure = measure;
  }

  // Bridge
  // (実装を呼び出し、橋渡しをする)
  public string GetName()
  {
    return _measure.GetName();
  }
  public string GetMeasure()
  {
    return _measure.GetMeasure();
  }

  public abstract string GetBatteryLevel();
  public abstract string GetDeviceName();

  public string GetSensitivity()
  {
    Sensitivity sensitivity = new Sensitivity(NumberHelper.Get100RandomNumberString());
    return sensitivity.DisplayValue;
  }
}
