using BridgePattern.Exeptions;
using BridgePattern.Repositories;
using BridgePattern.ValueObjects;

namespace BridgePattern.Infrastructure.DataConnector;


internal sealed class TextFile : IDataRepository
{
  private string _filePath;
  public TextFile(string filePath)
  {
    _filePath = filePath;

  }
  public async Task<string> Get()


  {
    try
    {
      // 仮にUI層がデータを持っているとする
      string filePath = _filePath;
      string fileContents = await File.ReadAllTextAsync(filePath);

      return fileContents;
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
}
