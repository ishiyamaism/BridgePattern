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
    protected override bool EqualsCore(Sensitivity other)
    {
        return this.Value == other.Value;
    }
}
