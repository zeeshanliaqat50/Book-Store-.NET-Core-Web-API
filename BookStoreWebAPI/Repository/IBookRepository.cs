using BookStoreWebAPI.Data;

namespace BookStoreWebAPI.Repository
{
    public interface IBookRepository
    {
        public  Task<List<Book>> GetAll();
        public Task<Book> GetById(int id);
        public Task<int> SaveBook(Book book);
        public Task<bool> UpdateBook(int id, Book book);
    }
}
