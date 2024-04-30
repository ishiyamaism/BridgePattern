using System.Runtime.InteropServices;
using BridgePattern.Exeptions;
using BridgePattern.Repositories;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.Measures;

public sealed class AutoTemperatureMeasure : IMeasure
{
  // ここでデータソースの取得方法を定める
  private static IDataRepository _dataRepository = DataFactory.Create(DataType.AutoTemperature);

  public string GetMeasure()
  {
    try
    {
      var data = _dataRepository.Get();

      Temperature temperature = new Temperature(data.Result);

      return temperature.DisplayValue;

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

  public string GetName()
  {
    return "自動温度";
  }
}
