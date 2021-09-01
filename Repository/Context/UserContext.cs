namespace Repository.Context
{
    using Fundoonotes.Models;
    using Microsoft.EntityFrameworkCore;
    using global::Models;

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<RegisterModel> Users { get; set; }
        public DbSet<NotesModel> Notes { get; set; }
    }
}
