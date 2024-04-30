using BridgePattern.Infrastructure.Devices;

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
    return new WindBatteryDevice();
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
