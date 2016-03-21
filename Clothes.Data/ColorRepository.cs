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
    public class ColorRepository : IRepository<ClothesColorDTO>
    {
        public void Create(ClothesColorDTO entity)
        {
            ClothesColor color = new ClothesColor();
            color = Mapper.Map<ClothesColorDTO, ClothesColor>(entity);

            using (var db = new ClothesDbContext())
            {
                if (entity != null)
                {
                    db.Colors.Add(color);

                    db.SaveChanges();
                }
            }
        }

        public ICollection<ClothesColorDTO> ReadAll()
        {
            ICollection<ClothesColorDTO> colors = new ObservableCollection<ClothesColorDTO>();

            using (var db = new ClothesDbContext())
            {
                colors = Mapper.Map<ICollection<ClothesColor>, ICollection<ClothesColorDTO>>(db.Colors.ToList());
                return colors;
            }
        }

        public void Update(ClothesColorDTO entity)
        {
            ClothesColor color = new ClothesColor();
            color = Mapper.Map<ClothesColorDTO, ClothesColor>(entity);

            using (var db = new ClothesDbContext())
            {
                //Todo: Add custom logic to check if another object like this exist in the data base.
                var newColors = db.Colors.Where(col => col.Id == color.Id).FirstOrDefault();
                newColors = color;
                db.SaveChanges();
            }
        }

        public void Delete(ClothesColorDTO entity)
        {
            ClothesColor color = new ClothesColor();
            color = Mapper.Map<ClothesColorDTO, ClothesColor>(entity);

            using (var db = new ClothesDbContext())
            {
                var deletedColor = db.Colors.Where(x => x.Name == color.Name).FirstOrDefault();
                db.Colors.Remove(deletedColor);
                db.SaveChanges();
            }
        }

        public ClothesColorDTO Read(int id)
        {
            ClothesColorDTO color = new ClothesColorDTO();

            using (var db = new ClothesDbContext())
            {
                color = Mapper.Map<ClothesColor, ClothesColorDTO>(db.Colors.Where(pr => pr.Id == id).FirstOrDefault());
                return color;
            }
        }
    }
}
