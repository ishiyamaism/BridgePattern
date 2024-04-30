using BridgePattern.Exeptions;
using BridgePattern.Modules.Helpers;
using BridgePattern.Repositories;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.Devices;

public sealed class WindBatteryDevice : Device
{
  // ここでデータソースの取得方法を定める
  private static IDataRepository _dataRepository = DataFactory.Create(DataType.WindSpeed);

  // 抽象クラスでの抽象メソッド以外に「拡張」するケース
  public override string GetBatteryLevel()
  {
    return $"{NumberHelper.Get100RandomNumber()} %";
  }

  public override string GetMeasure()
  {

    try
    {
      var data = _dataRepository.Get();

      WindSpeed ws = new WindSpeed(data.Result);

      return ws.DisplayValue;

    }
    catch (FileNotFoundException)
    {
      throw new InputDataException("風力データファイルが見つかりません");
    }
    catch (Exception ex)
    {
      throw new InputDataException($"入力データエラー: {ex.Message}");
    }
  }

  public override string GetName() => "風力バッテリー";
}
