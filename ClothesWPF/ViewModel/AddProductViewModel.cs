
using Clothes.Data;
using Clothes.Models;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Clothes.Models.ModelsDTO;

namespace ClothesWPF.ViewModel
{
    public class AddProductViewModel
    {
        public AddProductViewModel()
        {
            this.Product = new ProductDTO();
            CategoryRepository = new CategoryRepository();
            ColorRepository = new ColorRepository();
            SupplierRepository = new SupplierRepository();
            ProductRepository = new ProductRepository();

            Suppliers = new ObservableCollection<SupplierDTO>(SupplierRepository.ReadAll());
            Colors = new ObservableCollection<ClothesColorDTO>(ColorRepository.ReadAll());
            Categories = new ObservableCollection<CategoryDTO>(CategoryRepository.ReadAll());
        }

        public ProductDTO Product { get; set; }

        public ProductRepository ProductRepository { get; set; }

        public ColorRepository ColorRepository { get; set; }

        public ICollection<ClothesColorDTO> Colors { get; set; }

        public SupplierRepository SupplierRepository { get; set; }

        public ICollection<SupplierDTO> Suppliers { get; set; }

        public CategoryRepository CategoryRepository { get; set; }

        public ICollection<CategoryDTO> Categories { get; set; }

        public void AddProduct(ProductDTO product)
        {
            ProductRepository.Create(product);           
        }
    }
}
