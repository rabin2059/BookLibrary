using BookLibrary.Data;
using BookLibrary.DTOs.Request;
using BookLibrary.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Controllers
{
    [Route("api/bookcrud")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AdminDbContext _context;

        public BookController(AdminDbContext context)
        {
            _context = context;
        }


        [HttpGet("create")]
        [Authorize(Policy = "RequireAdminRole")]

        public async Task<ActionResult<CreateBookDTO>> CreateBook(CreateBookDTO createBook)
        {
            if (await _context.Books.AnyAsync(b => b.Title == createBook.Title))
            {
                return BadRequest("Book already exists");
            }

            if (await _context.Books.AnyAsync(b => b.ISBN == createBook.ISBN))
            {
                return BadRequest("Book already exists");
            }

            var book = new Book
            {
                BookId = Guid.NewGuid(),
                Title = createBook.Title,
                Author = createBook.Author,
                Genre = createBook.Genre,
                ISBN = createBook.ISBN,
                Description = createBook.Description,
                Publisher = createBook.Publisher,
                PublicationDate = createBook.PublicationDate,
                Price = createBook.Price,
                Quantity = createBook.Quantity,
                ImageUrl = createBook.ImageUrl,
                AvailableInLibrary = true,
                IsOnSale = false
            };
            // Save to database
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            // Return success response
            return Ok(new
            {
                message = "Book created successfully",
                data = book
            });
        }

        [HttpGet("getallbooks")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }
    }
}
