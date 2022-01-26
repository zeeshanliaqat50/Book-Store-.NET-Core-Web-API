using BookStoreWebAPI.Data;
using BookStoreWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this._bookRepository= bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var books = await _bookRepository.GetAll();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getById([FromRoute]int id)
        {
            var record=await _bookRepository.GetById(id);
            if (record == null)
                return NotFound("Invalid ID");
            return Ok(record);
        }
        [HttpPost]
        public async Task<IActionResult> SaveBook([FromBody]Book book)
        {
            await this._bookRepository.SaveBook(book);
            return Ok(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]Book book)
        {
          var r= await this._bookRepository.UpdateBook(id, book);

            return Ok(r); 



        }
    }
}
