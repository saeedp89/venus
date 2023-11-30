namespace Venus.Domain;

public record Identity : ValueOf<Guid>
{
    public static implicit operator Identity(Guid value)
    {
        return new Identity
        {
            Value = value
        };
    }
}