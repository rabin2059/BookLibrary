using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Model;


public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = "User"; 
    public bool IsVerified { get; set; } = true; 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CompleteOrderCount { get; set; } = 0;


    public ICollection<WhiteList> Whitelists { get; set; }
    public ICollection<CartItem> AddtoCarts { get; set; }

}
