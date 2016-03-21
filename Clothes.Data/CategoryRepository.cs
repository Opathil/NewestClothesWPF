using Clothes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothes.Models.ModelsDTO;
using AutoMapper;
using System.Collections.ObjectModel;

namespace Clothes.Data
{
    public class CategoryRepository : IRepository<CategoryDTO>
    {
        public void Create(CategoryDTO entity)
        {
            Category category = new Category();
            category = Mapper.Map<CategoryDTO, Category>(entity);

            using (var db = new ClothesDbContext())
            {
                if (category != null)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
            }
        }

        public ICollection<CategoryDTO> ReadAll()
        {
            ICollection<CategoryDTO> categories = new ObservableCollection<CategoryDTO>();

            using (var db = new ClothesDbContext())
            {
                categories = Mapper.Map<ICollection<Category>, ICollection<CategoryDTO>>(db.Categories.ToList());
                return categories;
            }
        }

        public void Update(CategoryDTO entity)
        {
            Category category = new Category();
            category = Mapper.Map<CategoryDTO, Category>(entity);

            using (var db = new ClothesDbContext())
            {
                //Todo: Add custom logic to check if another object like this exist in the data base.
                var newCategory = db.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
                newCategory = category;
                db.SaveChanges();
            }
        }

        public void Delete(CategoryDTO entity)
        {
            Category category = new Category();
            category = Mapper.Map<CategoryDTO, Category>(entity);

            using (var db = new ClothesDbContext())
            {
                var deleteCategory = db.Categories.Where(x => x.Name == category.Name).FirstOrDefault();
                db.Categories.Remove(deleteCategory);
                db.SaveChanges();
            }
        }

        public CategoryDTO Read(int id)
        {
            CategoryDTO category = new CategoryDTO();            

            using (var db = new ClothesDbContext())
            {
                category = Mapper.Map<Category, CategoryDTO>(db.Categories.Where(pr => pr.Id == id).FirstOrDefault());
                return category;
            }
        }
    }
}
