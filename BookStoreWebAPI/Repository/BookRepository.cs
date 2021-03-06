using BookStoreWebAPI.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookStoreContext _context { get; set; }
        public BookRepository(BookStoreContext context) //here dbcontext which has been registered in program.cs has been used via dependency Injection

        {
            this._context = context;
        }
        public async Task<List<Book>> GetAll()
        {
            var records = await _context.Books.ToListAsync();
            return records;
        }
        public async Task<Book> GetById(int id)
        {
            var record = await _context.Books.Where(x => x.id == id).FirstOrDefaultAsync();
            if (record == null)
            {
                return null;
            }
            else
                return record;

        }
        public async Task<int> SaveBook(Book book)
        {
            _context.Books.Add(book);
           await _context.SaveChangesAsync();
            return book.id;
        }
        public async Task<bool> UpdateBook(int id, Book book)
        {
            var record = await _context.Books.FindAsync(id); //find method only works if primary key is passed otherwise use where clause
            if(record!=null)
            {
                record.id = book.id;
                record.description=book.description;
                record.title = book.title;

                await _context.SaveChangesAsync();


                return true;
            }
            return false;
            
            

        }

       
        public async Task UpdateField(int id, JsonPatchDocument book)
        {
            var record = await _context.Books.FindAsync(id);
            if(record!=null)
            {
                book.ApplyTo(record);
               await this._context.SaveChangesAsync();
                  
            
         }
        }

        public async Task<bool> Delete(int id)
        {
            var record = _context.Books.Find(id);
            //alternative approach
           // Book b = new Book() { id=id};
            //_context.Books.Remove(b);
            //
            if(record!=null)
            {
                _context.Books.Remove(record);
              await  _context.SaveChangesAsync();    
                return true;
            }

            return false;
        }
    }
}
