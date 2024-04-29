using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

// 状態を同一視するためのインターフェース
public interface IState
{
  void OnUpdate(StateMachine stateMachine);

  string GetStateText();

  Device GetStateDevice();

  // State固有の何らかの情報を取得するなど用
  IEnumerable<string> GetCommand();


}
