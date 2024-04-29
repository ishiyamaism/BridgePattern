namespace BridgePattern.ValueObjects;

/// <summary>
/// 温度にまつわる温度データについてのValueObject
/// </summary>
public sealed class Temperature : ValueObject<Temperature>
{
    public Temperature(string dataString)
    {
        Value = dataString.Trim();
    }

    public string Value { get; private set; }

    public string DisplayValue
    {
        get
        {
            return $"{Value} ℃"; ;
        }
    }

    protected override bool EqualsCore(Temperature other)
    {
        return this.Value == other.Value;
    }
}
