using Microsoft.EntityFrameworkCore;

namespace BookHead.Models;

public class denemeDbContext : DbContext
{
    public denemeDbContext(DbContextOptions<denemeDbContext> options)
    : base(options)
    { }
    
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    

}