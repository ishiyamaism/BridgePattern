using BridgePattern.Infrastructure.Devices;

namespace BridgePattern.UI.States;

// 状態管理のためのクラス
public sealed class StateMachine
{
  // 最初は温度モードとする
  private IState _state = TemperatureState.Instance;

  // State変化監視用のオブザーバー
  public event Action? StateChanged;


  // State変更時
  public void Update()
  {
    // 状態を変え、
    _state.OnUpdate(this);
  }

  // State終了時
  public void Exit()
  {
    // State終了時処理
  }

  public string GetText()
  {
    return _state.GetStateText();
  }
  public Device GetDevice()
  {
    return _state.GetStateDevice();
  }
  internal void ChangeState(IState state)
  {
    _state = state;
    // State変更時にクライアントに通知
    StateChanged?.Invoke();
  }
}
