using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.UI.States;

public sealed class TemperatureBatteryState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private TemperatureBatteryState() { }
  public static TemperatureBatteryState Instance { get; } = new TemperatureBatteryState();

  public string GetStateText()
  {
    return "温度バッテリー測定モード";
  }
  public Device GetStateDevice()
  {
    // 測定するのは温度であり、
    IMeasure measure = new TemperatureMeasure();
    // 電源はバッテリー
    return new BatteryDevice(measure);
  }

  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {
    stateMachine.ChangeState(WindBatteryState.Instance);
  }
}
