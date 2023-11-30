using System.Linq.Expressions;
using System.Reflection;

namespace Venus.Domain;

public class Id : ValueOf<Guid, Id>
{

}
public class ValueOf<TValue, TThis> where TThis : ValueOf<TValue, TThis>, new()
{
    private static readonly Func<TThis> Factory;

    protected virtual void Validate()
    {
    }

    protected virtual bool TryValidate()
    {
        return true;
    }

    static ValueOf()
    {
        ConstructorInfo ctor = typeof(TThis)
            .GetTypeInfo()
            .DeclaredConstructors
            .First();
        var argsExp = Array.Empty<Expression>();
        NewExpression newExp = Expression.New(ctor, argsExp);
        LambdaExpression lambda = Expression.Lambda(typeof(Func<TThis>), newExp);
        Factory = (Func<TThis>)lambda.Compile();
    }

    public TValue Value { get; protected set; }

    public static TThis From(TValue item)
    {
        TThis x = Factory();
        x.Value = item;
        x.Validate();

        return x;
    }

    public static bool TryFrom(TValue item, out TThis thisValue)
    {
        TThis x = Factory();
        x.Value = item;
        thisValue = x.TryValidate() ? x : null;
        return thisValue != null;
    }

    protected virtual bool Equals(ValueOf<TValue, TThis> other)
    {
        return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj))
            return true;
        return obj.GetType() == GetType() && Equals((ValueOf<TValue, TThis>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TValue>.Default.GetHashCode(Value);
    }

    public static bool operator ==(ValueOf<TValue, TThis> a, ValueOf<TValue, TThis> b)
    {
        if (a is default(ValueOf<TValue, TThis>) && b is default(ValueOf<TValue, TThis>))
            return true;
        if (a is default(ValueOf<TValue, TThis>) || b is default(ValueOf<TValue, TThis>))
            return false;
        return a.Equals(b);
    }

    public static bool operator !=(ValueOf<TValue, TThis> a, ValueOf<TValue, TThis> b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}