using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothes.Data;
using Clothes.Models.ModelsDTO;

namespace ClothesWPF.ViewModel
{
    public class StockWindowViewModel : INotifyPropertyChanged
    {
        private ICollection<ProductDTO> products;

        public StockWindowViewModel()
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

