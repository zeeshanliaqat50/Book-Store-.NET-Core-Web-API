﻿using Microsoft.AspNetCore.Identity;

namespace BookStoreWebAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }    
    }
}
