using BookStoreWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager) //here dependency injucntion of userManager is being used that
            //is used to add and remove user not of DBContext class
        {
            this._userManager = userManager;
            
        }

        public async Task<IdentityResult> SignUp(SignUp signUp)
        {
            var user = new ApplicationUser()
            {
                FirstName=signUp.FirstName,
                LastName=signUp.LastName,
                Email=signUp.Email,
                UserName=signUp.Email,
            };
            return await _userManager.CreateAsync(user, signUp.password);
        }
    }
}
