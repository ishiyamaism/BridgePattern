using BridgePattern.Exeptions;
using BridgePattern.Modules.Helpers;
using BridgePattern.Repositories;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.DataConnector;


internal sealed class AutoSensor : IDataRepository
{
  public async Task<string> Get()
  {
    try
    {
      // センサーが自動的に温度を返す、ような想定
      return await Task.Run(() => NumberHelper.Get100RandomNumberString());
    }
    catch (FileNotFoundException)
    {
      throw new InputDataException("温度データが見つかりません");
    }
    catch (Exception ex)
    {
      throw new InputDataException($"入力データエラー: {ex.Message}");
    }
  }
}
