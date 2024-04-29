
using BridgePattern.Infrastructure.DataConnector;
using BridgePattern.Repositories;

namespace BridgePattern.Infrastructure;

/// <summary>
/// 様々のデータソースがある前提
/// </summary>
public static class DataFactory
{
  public static IDataRepository Create(DataType dataType)
  {
    if (dataType == DataType.Temperature)
    {
      return new TextFile("./Data/temp01.txt");
    }
    else if (dataType == DataType.WindSpeed)
    {
      return new TextFile("./Data/wind01.txt");
    }



    // 他の種類のデータファイルがあるかもしれない
    // 他にもAPI通信で得るかもしれない

    // 指定がどれにも該当しない場合はエラー
    throw new Exception("DataType指定エラー");
  }
}

public enum DataType
{
  Temperature,
  WindSpeed,
}
