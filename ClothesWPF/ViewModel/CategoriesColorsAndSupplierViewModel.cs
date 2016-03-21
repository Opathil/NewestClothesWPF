namespace ClothesWPF.ViewModel
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using Clothes.Models.ModelsDTO;
    using Clothes.Models;
    using Clothes.Data;
    using System.ComponentModel;

    public class CategoriesColorsAndSupplierViewModel : INotifyPropertyChanged
    {
        // private ICollection<CategoryDTO> categories;
        //
        // private ICollection<SupplierDTO> suppliers;
        //
        // private ICollection<ClothesColorDTO> colors;

        public CategoriesColorsAndSupplierViewModel()
        {
            this.Supplier = new SupplierDTO();
            this.Color = new ClothesColorDTO();
            this.Category = new CategoryDTO();
            CategoryRepository = new CategoryRepository();
            SupplierRepository = new SupplierRepository();
            ColorRepository = new ColorRepository();
            this.Categories = new ObservableCollection<CategoryDTO>(CategoryRepository.ReadAll());
            this.Suppliers = new ObservableCollection<SupplierDTO>(SupplierRepository.ReadAll());
            this.Colors = new ObservableCollection<ClothesColorDTO>(ColorRepository.ReadAll());
        }

        public CategoryDTO Category { get; set; }

        public SupplierDTO Supplier { get; set; }

        public ClothesColorDTO Color { get; set; }

        public ColorRepository ColorRepository { get; set; }

        public CategoryRepository CategoryRepository { get; set; }

        public SupplierRepository SupplierRepository { get; set; }

        public ICollection<CategoryDTO> Categories { get; set; }

        public ICollection<SupplierDTO> Suppliers { get; set; }

        public ICollection<ClothesColorDTO> Colors { get; set; }

        //public ICollection<CategoryDTO> Categories
        //{
        //    get
        //    {
        //        return this.categories;
        //    }
        //    set
        //    {
        //        this.categories = value;
        //        OnPropertyChanged("Categories");
        //    }
        //}

        //public ICollection<SupplierDTO> Suppliers
        //{
        //    get
        //    {
        //        return this.suppliers;
        //    }
        //    set
        //    {
        //        this.suppliers = value;
        //        OnPropertyChanged("Suppliers");
        //    }
        //}

        //public ICollection<ClothesColorDTO> Colors
        //{
        //    get
        //    {
        //        return this.colors;
        //    }
        //    set
        //    {
        //        this.colors = value;
        //        OnPropertyChanged("Colors");
        //    }
        //}


        public void AddCategory()
        {
            CategoryRepository.Create(Category);
            Categories.Add(Category);
        }

        public void AddSupplier()
        {
            SupplierRepository.Create(Supplier);
            Suppliers.Add(Supplier);
        }

        public void AddColor()
        {
            ColorRepository.Create(Color);
            Colors.Add(Color);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
