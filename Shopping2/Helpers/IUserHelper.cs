﻿using Microsoft.AspNetCore.Identity;
using Shopping2.Data.Entities;
using Shopping2.Models;

namespace Shopping2.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

		Task<User> AddUserAsync(AddUserViewModel model);

		Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


    }
}
