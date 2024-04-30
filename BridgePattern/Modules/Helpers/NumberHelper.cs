namespace BridgePattern.Modules.Helpers;

public static class NumberHelper
{
  public static int Get100RandomNumber()
  {
    Random _random = new Random();
    return _random.Next(0, 100);
  }

  public static string Get100RandomNumberString()
  {
    return Get100RandomNumber().ToString();
  }
}
