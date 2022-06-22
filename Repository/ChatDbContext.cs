using Domain;
using Domain.apiDomain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ChatDbContext : DbContext
{
    private const string connectionString =
        "server=localhost;port=3306;database=ChatAppDB;user=root;password=Yu*g3Q^9i&L4r7";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactApi>().HasKey(nameof(ContactApi.Id), nameof(ContactApi.contactOf));
        modelBuilder.Entity<User>().HasKey(nameof(User.Id));
        modelBuilder.Entity<Conversation>().HasKey(nameof(Conversation.Id));
    }

    public DbSet<ContactApi> Contacts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
}