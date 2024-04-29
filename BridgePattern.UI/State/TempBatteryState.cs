using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

public sealed class TempBatteryState : IState
{
  private TempBatteryState() { }
  public static TempBatteryState Instance { get; } = new TempBatteryState();

  public string GetStateText()
  {
    return "温度バッテリー測定モード";
  }
  public Device GetStateDevice()
  {
    return new TempBatteryDevice();
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
