using System;

namespace BookLibrary.DTOs.Response;

public class CartItemDTO
{
    public Guid CartItemId { get; set; }

    public Guid BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string ImageUrl { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public int Discount { get; set; }

    public int FinalPrice => Discount > 0 ? Price - (Price * Discount / 100) : Price;

    public DateTime AddedAt { get; set; }
}
