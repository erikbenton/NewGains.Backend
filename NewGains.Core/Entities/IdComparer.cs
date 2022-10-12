namespace NewGains.Core.Entities;

public class IdComparer<T> : IEqualityComparer<T>
    where T : IIdEntity
{
    public bool Equals(T? x, T? y)
    {
        return x?.Id == y?.Id;
    }

    public int GetHashCode(T obj)
    {
        return obj.Id.GetHashCode();
    }
}
