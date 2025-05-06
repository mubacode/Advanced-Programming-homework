public class Quartet<T1, T2, T3, T4> : IComparable<Quartet<T1, T2, T3, T4>> where T1 : IComparable<T1>
{
    private T1 _id;
    private T2 _second;
    private T3 _third;
    private T4 _fourth;

    public T1 Id
    {
        get => _id;
        set => _id = value;
    }

    public T2 Second
    {
        get => _second;
        set => _second = value;
    }

    public T3 Third
    {
        get => _third;
        set => _third = value;
    }

    public T4 Fourth
    {
        get => _fourth;
        set => _fourth = value;
    }

    public Quartet()
    {
        _id = default;
        _second = default;
        _third = default;
        _fourth = default;
    }

    public Quartet(T1 id, T2 second, T3 third, T4 fourth)
    {
        _id = id;
        _second = second;
        _third = third;
        _fourth = fourth;
    }

    public override string ToString()
    {
        return $"[{_id}, {_second}, {_third}, {_fourth}]";
    }

    public override bool Equals(object obj)
    {
        if (obj is Quartet<T1, T2, T3, T4> other)
        {
            return _id.Equals(other._id);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }

    public int CompareTo(Quartet<T1, T2, T3, T4> other)
    {
        if (other == null) return 1;
        return _id.CompareTo(other._id);
    }
}