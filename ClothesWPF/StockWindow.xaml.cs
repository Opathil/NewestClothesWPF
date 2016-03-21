using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Clothes.Models.ModelsDTO;
using ClothesWPF.ViewModel;

namespace ClothesWPF
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        public StockWindowViewModel ViewModel { get; set; }

        public StockWindow()
        {
            InitializeComponent();
            this.ViewModel = new StockWindowViewModel();
            this.DataContext = ViewModel;            
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {            
            var selectedProduct = ShowProducts.SelectedItem;

            if (selectedProduct == null)
            {
                MessageBox.Show("Моля посочете продукт.");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox
                .Show(string.Format("Искате ли да изтриете продуктът {0}?", ((ProductDTO)selectedProduct).Name), "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)  // error is here
                {
                    ViewModel.Repository.Delete((ProductDTO)selectedProduct);
                    ViewModel.Products.Remove((ProductDTO)selectedProduct);
                }
            }            
        }

        private void QuantityChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ShowProducts.SelectedItem;
            EditQuantityWindow quantityWindow = new EditQuantityWindow((ProductDTO)selectedProduct);
            quantityWindow.ShowDialog();

        }
    }
}
