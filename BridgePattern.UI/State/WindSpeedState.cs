using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

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
    // 測定するのは風力であり、電源はAC
    return new ACDevice(new WindMeasure());
  }
  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {// Stateパターン (次の状態を自身が有する)
    stateMachine.ChangeState(WindBatteryState.Instance);
  }
}
