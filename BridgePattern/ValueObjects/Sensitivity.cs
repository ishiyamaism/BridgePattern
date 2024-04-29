namespace BridgePattern.ValueObjects;

/// <summary>
/// 感度にまつわる感度データについてのValueObject
/// </summary>
public sealed class Sensitivity : ValueObject<Sensitivity>
{
    public Sensitivity(string dataString)
    {
        Value = dataString.Trim();
    }

    public string Value { get; private set; }

    public string DisplayValue
    {
        get
        {
            return $"{Value} dBr";
        }
    }

    protected override bool EqualsCore(Sensitivity other)
    {
        return this.Value == other.Value;
    }
}
