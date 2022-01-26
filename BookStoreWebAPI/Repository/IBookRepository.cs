using BookStoreWebAPI.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStoreWebAPI.Repository
{
    public interface IBookRepository
    {
        public  Task<List<Book>> GetAll();
        public Task<Book> GetById(int id);
        public Task<int> SaveBook(Book book);
        public Task<bool> UpdateBook(int id, Book book);

        public Task UpdateField(int id, JsonPatchDocument book); //for httpPatch Operation

        public Task<bool> Delete(int id);

    }
}
