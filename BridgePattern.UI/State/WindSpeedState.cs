using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

public sealed class WindSpeedState : IState
{
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
  {
    stateMachine.ChangeState(TempBatteryState.Instance);
  }
}
