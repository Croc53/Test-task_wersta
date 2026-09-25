namespace TestTaskWersta.Data;

public interface IOrderNumberGenerator
{
    string Generate();
}
public class OrderNumberGenerator : IOrderNumberGenerator
{
    public string Generate()
    {
        var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
        var suffix = Guid.NewGuid().ToString("N")[..4].ToUpperInvariant();
        return $"ORD-{datePart}-{suffix}";
    }
}