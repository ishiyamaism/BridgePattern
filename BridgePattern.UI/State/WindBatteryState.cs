using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.UI.States;

public sealed class WindBatteryState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private WindBatteryState() { }
  public static WindBatteryState Instance { get; } = new WindBatteryState();

  public string GetStateText()
  {
    return "風力バッテリー測定モード";
  }
  public Device GetStateDevice()
  {
    // 測定するのは風力であり、
    IMeasure measure = new WindMeasure();
    // 電源はバッテリー
    return new BatteryDevice(measure);
  }

  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {
    // Stateパターン (次の状態を自身が有する)
    stateMachine.ChangeState(TemperatureState.Instance);
  }
}
