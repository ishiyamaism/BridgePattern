using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.UI.States;

public sealed class TemperatureSunState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private TemperatureSunState() { }
  public static TemperatureSunState Instance { get; } = new TemperatureSunState();

  public string GetStateText()
  {
    return "温度太陽光測定モード";
  }
  public Device GetStateDevice()
  {
    // 測定するのは温度であり、電源は太陽光
    return new SunDevice(new TemperatureMeasure());
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
