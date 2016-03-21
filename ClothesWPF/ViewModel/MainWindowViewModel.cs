namespace ClothesWPF.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Clothes.Data;
    using Clothes.Models;
    using Clothes.Models.ModelsDTO;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICollection<ProductDTO> products;

        public MainWindowViewModel()
        {
            this.Repository = new ProductRepository();
            this.Products = new ObservableCollection<ProductDTO>(Repository.ReadAll());
        }

        public ICollection<ProductDTO> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
                OnPropertyChanged("Products");
            }
        }

        public ProductRepository Repository { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
