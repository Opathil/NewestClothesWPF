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
    public class SupplierRepository : IRepository<SupplierDTO>
    {
        public void Create(SupplierDTO entity)
        {
            Supplier supplier = new Supplier();
            supplier = Mapper.Map<SupplierDTO, Supplier>(entity);

            using (var db = new ClothesDbContext())
            {
                if (supplier != null)
                {
                    db.Suppliers.Add(supplier);
                    db.SaveChanges();
                }
            }
        }

        public ICollection<SupplierDTO> ReadAll()
        {
            ICollection<SupplierDTO> suppliers = new ObservableCollection<SupplierDTO>();

            using (var db = new ClothesDbContext())
            {
                suppliers = Mapper.Map<ICollection<Supplier>, ICollection<SupplierDTO>>(db.Suppliers.ToList());
                return suppliers;
            }
        }

        public void Update(SupplierDTO entity)
        {
            Supplier supplier = new Supplier();
            supplier = Mapper.Map<SupplierDTO, Supplier>(entity);

            using (var db = new ClothesDbContext())
            {
                //Todo: Add custom logic to check if another object like this exist in the data base.
                var newSupplier = db.Suppliers.Where(sup => sup.Id == supplier.Id).FirstOrDefault();
                newSupplier = supplier;
                db.SaveChanges();
            }
        }

        public void Delete(SupplierDTO entity)
        {
            Supplier supplier = new Supplier();
            supplier = Mapper.Map<SupplierDTO, Supplier>(entity);

            using (var db = new ClothesDbContext())
            {
                var deletedSupplier = db.Suppliers.Where(x => x.Name == supplier.Name).FirstOrDefault();
                db.Suppliers.Remove(deletedSupplier);
                db.SaveChanges();
            }
        }

        public SupplierDTO Read(int id)
        {
            SupplierDTO supplier = new SupplierDTO();

            using (var db = new ClothesDbContext())
            {
                supplier = Mapper.Map<Supplier, SupplierDTO>(db.Suppliers.Where(pr => pr.Id == id).FirstOrDefault());
                return supplier;
            }
        }
    }
}
