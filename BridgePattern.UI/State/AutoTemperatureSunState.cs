using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;

namespace BridgePattern.UI.States;

public sealed class AutoTemperatureSunState : IState
{
  // 状態インスタンスは必ず１つなのでSingletonパターン
  private AutoTemperatureSunState() { }
  public static AutoTemperatureSunState Instance { get; } = new AutoTemperatureSunState();

  public string GetStateText()
  {
    return "自動温度太陽光測定モード";
  }
  public Device GetStateDevice()
  {
    // 測定するのは自動温度であり、電源は太陽光
    return new SunDevice(new AutoTemperatureMeasure());
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
