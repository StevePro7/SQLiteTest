using Microsoft.EntityFrameworkCore;

namespace MySQLiteTest
{
    public class DataContext : DbContext
    {
        private string _databasePath = "";

        public DataContext() : base()
        {
        }

        public DataContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();

            //// Android
            //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "invoiceje.db");

            //// UWP
            //var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "exrin.db");

            //// iOS
            //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "exrin.db");
        }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = _databasePath;
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }

}