using BridgePattern.Exeptions;
using BridgePattern.Repositories;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.Devices;

public sealed class TemperatureDevice : Device
{
  // ここでデータソースの取得方法を定める
  private static IDataRepository _dataRepository = DataFactory.Create(DataType.Temperature);

  public override string GetBatteryLevel()
  {
    return "-";
  }

  public override string GetMeasure()
  {

    try
    {
      var data = _dataRepository.Get();

      Temperature temperature = new Temperature(data.Result);

      return temperature.DisplayValue;

    }
    catch (FileNotFoundException)
    {
      throw new InputDataException("温度データファイルが見つかりません");
    }
    catch (Exception ex)
    {
      throw new InputDataException($"入力データエラー: {ex.Message}");
    }
  }

  public override string GetName() => "温度";
}
