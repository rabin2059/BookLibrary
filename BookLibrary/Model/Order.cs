using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Model;

public class Order
{
    [Key]
    public Guid OrderId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Required]
    public decimal OriginalTotal { get; set; }

    [Required]
    public decimal DiscountRate { get; set; } // e.g., 0.05 or 0.15

    [Required]
    public decimal FinalTotal { get; set; }

    [Required]
    public string Status { get; set; } = "Pending"; // or "Cancelled", "Completed"

    public string? ClaimCode { get; set; } // To match the scenario

    public ICollection<OrderItem> OrderItems { get; set; }
}