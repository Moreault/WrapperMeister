namespace ToolBX.WrapperMeister;

public interface IWrapper<T> : IEquatable<T>
{
    T Unwrapped { get; }
}

public abstract class Wrapper<T> : IWrapper<T>
{
    public T Unwrapped { get; }

    protected Wrapper(T unwrapped)
    {
        Unwrapped = unwrapped ?? throw new ArgumentNullException(nameof(unwrapped));
    }

    public bool Equals(IWrapper<T>? other) => other is not null && Equals(other.Unwrapped);

    public bool Equals(T? other) => Unwrapped!.Equals(other);

    public override bool Equals(object? obj)
    {
        if (obj is IWrapper<T> wrapper) return Equals(wrapper);
        return Unwrapped!.Equals(obj);
    }

    public override int GetHashCode() => Unwrapped!.GetHashCode();

    public static bool operator ==(Wrapper<T>? left, Wrapper<T>? right) => left?.Equals(right) ?? right is null;

    public static bool operator !=(Wrapper<T>? left, Wrapper<T>? right) => !(left == right);

    public static bool operator ==(Wrapper<T>? left, T? right) => left?.Equals(right) ?? right is null;

    public static bool operator !=(Wrapper<T>? left, T? right) => !(left == right);

    public override string ToString() => Unwrapped!.ToString() ?? string.Empty;

    public static explicit operator T(Wrapper<T> wrapper) => wrapper.Unwrapped;
}