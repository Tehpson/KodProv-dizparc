using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataBase : DbContext
    {
        public string DatabaseFile { get; set; } = "BornStastitics.db";
        public DbSet<Models.BornModel>? BornStastitics { get; set; }
        public DbSet<Models.Region>? Regions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "VSDatabase");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseFile);

            optionsBuilder.UseSqlite("Data Source = " + path + ";");
        }
    }
}
