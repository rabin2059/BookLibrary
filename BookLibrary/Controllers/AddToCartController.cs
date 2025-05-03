using System.Security.Claims;
using BookLibrary.Data;
using BookLibrary.DTOs.Request;
using BookLibrary.DTOs.Response;
using BookLibrary.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/addToCart")]
    [ApiController]
    public class AddToCartController : ControllerBase
    {
        public readonly AuthDbContext _context;
        public AddToCartController(AuthDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        [Authorize(Policy = "RequireUserRole")]
        public async Task<ActionResult<CartItemDTO>> CreateCartItem(CreateCartItemDTO createCartItem){
           var userClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userClaim == null)
                return Unauthorized("Invalid! Token is missing");

            var userId = Guid.Parse(userClaim.Value);
            var book = await _context.Books.FindAsync(createCartItem.BookId);
            if (book == null)
                return NotFound("Book not found");

            if (book.Quantity < createCartItem.Quantity)
                return BadRequest("Not enough quantity available");

        
            var cartItem = new CartItem
            {
                CartItemId = Guid.NewGuid(),
                BookId = createCartItem.BookId,
                UserId = userId,
                Quantity = createCartItem.Quantity,
                PricePerUnit = book.Price
            };    


            // Add the cart item to the database    
            _context.CartItems.Add(cartItem);
          
            await _context.SaveChangesAsync();

            return Ok(new
            {
                status = "success",
                message = "Book added to cart successfully",
                statusCode = 200,
                data = cartItem
            });
        }
        
    }
}
