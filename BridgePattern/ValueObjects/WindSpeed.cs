namespace BridgePattern.ValueObjects;

/// <summary>
/// 風速にまつわる風速データについてのValueObject
/// </summary>
public sealed class WindSpeed : ValueObject<WindSpeed>
{
    public WindSpeed(string dataString)
    {
        Value = dataString.Trim();
    }

    public string Value { get; private set; }

    public string DisplayValue
    {
        get
        {
            return $"{Value} m/s"; ;
        }
    }
    public int IntValue
    {
        get
        {
            if (int.TryParse(Value, out int i))
            {
                return i;
            }
            return 0;
        }
    }

    protected override bool EqualsCore(WindSpeed other)
    {
        return this.Value == other.Value;
    }
}
