using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.UI.States;

public sealed class AutoTemperatureState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private AutoTemperatureState() { }
  public static AutoTemperatureState Instance { get; } = new AutoTemperatureState();

  public string GetStateText()
  {
    return "自動温度測定モード";
  }
  public Device GetStateDevice()
  {
    // 測定するのは自動温度であり、電源はAC
    return new ACDevice(new TemperatureMeasure());
  }

  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {
    // Stateパターン (次の状態を自身が有する)
    stateMachine.ChangeState(AutoTemperatureBatteryState.Instance);
  }
}
