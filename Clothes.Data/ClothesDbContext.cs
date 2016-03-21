namespace Clothes.Data
{
    using System.Data.Entity;
    using Models;

    public class ClothesDbContext : DbContext
    {
        public ClothesDbContext()
        {
            //this.Configuration.ProxyCreationEnabled = true;
        }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<ClothesColor> Colors { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Supplier> Suppliers { get; set; }

        public virtual IDbSet<Sale> Sales { get; set; }

        //Comment

        public virtual IDbSet<DailyReport> DailyReports { get; set; }
    }
}
