using BookStoreWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebAPI.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUp(SignUp signUp);

    }
}
