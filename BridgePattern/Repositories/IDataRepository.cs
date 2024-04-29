namespace BridgePattern.Repositories;

public interface IDataRepository
{
  Task<string> Get();
}
