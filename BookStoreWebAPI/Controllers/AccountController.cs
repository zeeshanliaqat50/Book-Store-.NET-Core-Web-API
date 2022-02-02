using BookStoreWebAPI.Models;
using BookStoreWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository= accountRepository;

        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUp signUp)
        {
            var result = await this._accountRepository.SignUp(signUp);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

    }
}
