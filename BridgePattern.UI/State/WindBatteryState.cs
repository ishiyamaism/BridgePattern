using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

public sealed class WindBatteryState : IState
{
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
    stateMachine.ChangeState(TemperatureState.Instance);
  }
}
