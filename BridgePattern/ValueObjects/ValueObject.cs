namespace BridgePattern.ValueObjects;
public abstract class ValueObject<T> where T : ValueObject<T>
{
    /// <summary>
    /// クラスインスタンスを値で判断するように
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        var vo = obj as T;
        if (vo == null)
        {
            return false;
        }

        return EqualsCore(vo);  // 各Object側で実装せよ
    }

    public static bool operator ==(ValueObject<T>? vo1, ValueObject<T>? vo2)
    {
        return Equals(vo1, vo2);
    }

    public static bool operator !=(ValueObject<T>? vo1, ValueObject<T>? vo2)
    {
        return !Equals(vo1, vo2);
    }

    protected abstract bool EqualsCore(T other);

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
