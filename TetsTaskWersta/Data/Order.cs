namespace TestTaskWersta.Models;

public class Order
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public string SenderCity { get; set; } = string.Empty;
    public string SenderAddress { get; set; } = string.Empty;
    public string RecipientCity { get; set; } = string.Empty;
    public string RecipientAddress { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public DateOnly PickupDate { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}