using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

public sealed class TemperatureState : IState
{
  private TemperatureState() { }
  public static TemperatureState Instance { get; } = new TemperatureState();

  public string GetStateText()
  {
    return "温度測定モード";
  }
  public Device GetStateDevice()
  {
    return new TemperatureDevice();
  }

  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {
    stateMachine.ChangeState(WindSpeedState.Instance);
  }
}
