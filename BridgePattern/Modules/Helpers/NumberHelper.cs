namespace BridgePattern.Modules.Helpers;

public static class NumberHelper
{
  public static int Get100RandomNumber()
  {
    Random _random = new Random();
    return _random.Next(0, 100);
  }
}
