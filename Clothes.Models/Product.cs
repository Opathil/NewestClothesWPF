namespace Clothes.Models
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        private ICollection<Sale> sale;

        public Product()
        {
            this.sale = new HashSet<Sale>();
        }

        public Product(Category Category, Supplier Supplier, ClothesColor Color, string Name)
        {
            this.ProductNumber = Guid.NewGuid();
            this.Category = Category;
            this.Supplier = Supplier;
            this.Color = Color;
            this.Name = Name;           
        }

        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }

        public Guid ProductNumber { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ClothesColor Color { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Sale> Sale
        {
            get { return this.sale; }
            set { this.sale = value; }
        }
        
    }
}
