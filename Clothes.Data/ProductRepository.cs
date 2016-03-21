using Clothes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothes.Models.ModelsDTO;
using System.Collections.ObjectModel;
using AutoMapper;

namespace Clothes.Data
{
    public class ProductRepository : IRepository<ProductDTO>
    {        
        //public void Create(Product entity, ClothesColor color, Supplier supplier, Category category)
        //{
        //    using (var db = new ClothesDbContext())
        //    {
        //        if (entity != null)
        //        {
        //            var foundCategory = db.Categories.Find(category);
        //            var foundColor = db.Colors.Find(color);
        //            var foundSupplier = db.Suppliers.Find(supplier);
        //            entity.Category = foundCategory;
        //            entity.Color = foundColor;
        //            entity.Supplier = foundSupplier;
        //            db.Products.Add(entity);

        //            db.SaveChanges();
        //        }
        //    }
        //}

        public ICollection<ProductDTO> ReadAll()
        {
            ICollection<ProductDTO> products = new ObservableCollection<ProductDTO>();

            using(var db = new ClothesDbContext())
            {
                //products = Mapper.Map<ICollection<Product>, ICollection<ProductDTO>>(db.Products.ToList());                
                return products;
            }
        }

        public void Update(ProductDTO entity)
        {
            var product = Mapper.Map<ProductDTO, Product> (entity);

            using (var db = new ClothesDbContext())
            {
                //Todo: Add custom logic to check if another object like this exist in the data base.
                var newProduct = db.Products.Where(pr => pr.Id == product.Id).FirstOrDefault();
                newProduct.Quantity = product.Quantity;
                db.SaveChanges();
            }
        }

        public void Delete(ProductDTO entity)
        {
            Product product = new Product();
            product = Mapper.Map<ProductDTO, Product>(entity);

            using (var db = new ClothesDbContext())
            {
                var deleteProduct = db.Products.Where(pr => pr.Name == product.Name).FirstOrDefault();
                db.Products.Remove(deleteProduct);
                db.SaveChanges();
            }
        }

        public void Create(ProductDTO entity)
        {

            Product product = new Product();
            product = Mapper.Map<ProductDTO, Product>(entity);

            using (var db = new ClothesDbContext())
            {
                if (product != null)
                {
                    var foundcategory = db.Categories.Where(c => c.Name == entity.CategoryName).FirstOrDefault();
                    var foundcolor = db.Colors.Where(col => col.Name == entity.ClothesColorName).FirstOrDefault();
                    var foundsupplier = db.Suppliers.Where(sup => sup.Name == entity.ClothesColorName).FirstOrDefault();
                    //var foundcategory = db.Categories.Find(entity.CategoryName);
                    //var foundcolor = db.Colors.Find(entity.ClothesColorName);
                    //var foundsupplier = db.Suppliers.Find(entity.SupplierName);
                    product.Category = foundcategory;
                    product.Color = foundcolor;
                    product.Supplier = foundsupplier;
                    db.Products.Add(product);

                    db.SaveChanges();
                }
            }
        }

        public ProductDTO Read(int id)
        {
            ProductDTO product = new ProductDTO();

            using (var db = new ClothesDbContext())
            {
                product = Mapper.Map<Product, ProductDTO>(db.Products.Where(pr => pr.Id == id).FirstOrDefault());
                return product;
            }
        }
    }
}
