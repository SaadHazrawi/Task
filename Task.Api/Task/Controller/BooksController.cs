using Application.Common.Dtos.Book;
using Core.common.filter;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System.Threading.Tasks;

namespace Task.Controller
{
    /// <summary>
    /// Controller for managing books.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        /// <summary>
        /// Get paginated list of books.
        /// </summary>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        [HttpGet("GetAllBooksWithPagination")]
        public async Task<IActionResult> GetBooks(int pageIndex, int pageSize)
        {
            var result = await _bookServices.GetAll(pageIndex, pageSize);
            return Ok(result);
        }  
        [HttpGet("GetAllBooksFilter")]
        public async Task<IActionResult> GetfilterBooks( [FromQuery]BookFilterDto filterDto)
        {
            var result = await _bookServices.GetBooksByFilter( filterDto);
            return Ok(result);
        } 
        [HttpGet("StroeeProcToGetBooksByCategoreyId/{subCatgoreyId}")]
        public  IActionResult GetBooksByCategoreyId(int subCatgoreyId)
        {
            var result = _bookServices.GetBooksBySubcategoryStoreProc(subCatgoreyId);
            return Ok(result);
        }

        /// <summary>
        /// Get a book by ID.
        /// </summary>
        /// <param name="id">Book ID.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var result = await _bookServices.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// Add a new book.
        /// </summary>
        /// <param name="bookAdd">Book data to add.</param>
        [HttpPost]
        public async Task<IActionResult> Add(BookAddDto bookAdd)
        {
            var result = await _bookServices.Add(bookAdd);
            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

        /// <summary>
        /// Delete a book by ID.
        /// </summary>
        /// <param name="id">Book ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookServices.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Update a book by ID.
        /// </summary>
        /// <param name="id">Book ID.</param>
        /// <param name="bookUpdate">Updated book data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookUpdateDto bookUpdate)
        {
            await _bookServices.Update(id, bookUpdate);
            return NoContent();
        }
    }
}
