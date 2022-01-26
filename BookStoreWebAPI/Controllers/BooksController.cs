using BookStoreWebAPI.Data;
using BookStoreWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpPatch("{id}")]
        /***
         * Patch is used to update some field only not the whole row or record
         * 
         * Request's body sample
         * [
  {
    "operationType": 0,
    "path": "title",   //field name
    "op": "replace",  
    "from": "string", 
    "value": "Updated field"  //new value
  }
]
         */
        public async Task<IActionResult> UpdateField([FromRoute]int id, [FromBody]JsonPatchDocument book)
        {
           await _bookRepository.UpdateField(id, book);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await this._bookRepository.Delete(id);
            return Ok(id);


        }
    }
}
