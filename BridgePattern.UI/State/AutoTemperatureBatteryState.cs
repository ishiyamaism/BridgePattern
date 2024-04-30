using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.UI.States;

public sealed class AutoTemperatureBatteryState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private AutoTemperatureBatteryState() { }
  public static AutoTemperatureBatteryState Instance { get; } = new AutoTemperatureBatteryState();

  public string GetStateText()
  {
    return "自動温度バッテリー測定モード";
  }
  public Device GetStateDevice()
  {
    // 測定するのは自動温度であり、電源はバッテリー
    return new BatteryDevice(new AutoTemperatureMeasure());
  }

  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {
    stateMachine.ChangeState(AutoTemperatureSunState.Instance);
  }
}
