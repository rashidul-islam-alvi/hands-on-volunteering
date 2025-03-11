using Microsoft.EntityFrameworkCore;
using server.Entities;
using System.Collections.Generic;

namespace server.Context
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)

    {
        public DbSet<User> User { get; set; }
    }
}
