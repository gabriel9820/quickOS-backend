﻿using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> CreateAsync(User user);
}
