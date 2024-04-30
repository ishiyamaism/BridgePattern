using System.Runtime.InteropServices;
using BridgePattern.Exeptions;
using BridgePattern.Repositories;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.Measures;

public sealed class WindMeasure : IMeasure
{
  // ここでデータソースの取得方法を定める
  private static IDataRepository _dataRepository = DataFactory.Create(DataType.WindSpeed);

  public string GetMeasure()
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

  public string GetName()
  {
    return "風力";
  }
}
