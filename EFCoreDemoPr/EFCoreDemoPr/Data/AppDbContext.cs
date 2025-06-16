using Microsoft.EntityFrameworkCore;


namespace EFCoreDemoPr.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
              new CurrencyType() {Id =1, Currency="INR",Description = "Indian Rupee"},
              new CurrencyType() {Id =2, Currency="Dinar",Description = "Dinar"},
              new CurrencyType() {Id =3, Currency="EURO",Description = "Euro"},
              new CurrencyType() {Id =4, Currency="USD",Description = "Dollar" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id=1, Title ="Hindi",Description="Hindi Translated"},
                new Language() { Id=2, Title ="Tamil",Description="Tamil Translated"},
                new Language() { Id=3, Title ="Kannada",Description="kannada Translated"},
                new Language() { Id=4, Title ="English",Description="English Translated"}
                );
        }
        public DbSet<Book> BooksTable { get; set; }
        public DbSet<Language> LanguageTable { get; set; }
        public DbSet<BookPrice> PriceTable { get; set; }
        public DbSet<CurrencyType> CurrencyTable { get; set; }
    }
}
