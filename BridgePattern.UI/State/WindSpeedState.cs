using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

public sealed class WindSpeedState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private WindSpeedState() { }
  public static WindSpeedState Instance { get; } = new WindSpeedState();

  public string GetStateText()
  {
    return "風速測定モード";
  }
  public Device GetStateDevice()
  {
    return new WindDevice();
  }
  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {// Stateパターン (次の状態を自身が有する)
    stateMachine.ChangeState(TemperatureBatteryState.Instance);
  }
}
