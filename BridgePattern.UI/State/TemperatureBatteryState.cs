using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

public sealed class TemperatureBatteryState : IState
{
  private TemperatureBatteryState() { }
  public static TemperatureBatteryState Instance { get; } = new TemperatureBatteryState();

  public string GetStateText()
  {
    return "温度バッテリー測定モード";
  }
  public Device GetStateDevice()
  {
    return new TemperatureBatteryDevice();
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
