using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.UI.States;

public sealed class WindSunState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private WindSunState() { }
  public static WindSunState Instance { get; } = new WindSunState();

  public string GetStateText()
  {
    return "風力太陽光測定モード";
  }
  public Device GetStateDevice()
  {
    // 測定するのは風力であり、電源は太陽光
    return new SunDevice(new WindMeasure());
  }

  public IEnumerable<string> GetCommand()
  {
    throw new NotImplementedException();
  }

  public void OnUpdate(StateMachine stateMachine)
  {
    // Stateパターン (次の状態を自身が有する)
    stateMachine.ChangeState(AutoTemperatureState.Instance);
  }
}
