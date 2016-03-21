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
using ClothesWPF.ViewModel;
using Clothes.Models;
using Clothes.Data;
using Clothes.Models.ModelsDTO;

namespace ClothesWPF
{
    /// <summary>
    /// Interaction logic for AddNewProductWindow.xaml
    /// </summary>
    public partial class AddNewProductWindow : Window
    {

        public AddProductViewModel ProductViewModel = new AddProductViewModel();

        public AddNewProductWindow()
        {
            InitializeComponent();
            this.DataContext = ProductViewModel;
        }

        private void AddNewProductClick(object sender, RoutedEventArgs e)
        {
            //ClothesColor color = new ClothesColor();

            ProductViewModel.Product.Name = AddProductName.Text;
            ProductViewModel.Product.Price = decimal.Parse(AddProductPrice.Text);
            ProductViewModel.Product.Size = AddProductSize.Text;
            ProductViewModel.Product.Quantity = int.Parse(AddProductQuantity.Text);
            ProductViewModel.Product.CategoryName = ((CategoryDTO)SelectProductCategory.SelectedItem).Name;
            ProductViewModel.Product.SupplierName = ((SupplierDTO)SelectProductSupplier.SelectedItem).Name;
            ProductViewModel.Product.ClothesColorName = ((ClothesColorDTO)SelectProductColor.SelectedItem).Name;

            //ProductViewModel.ProductRepository.Create(ProductViewModel.Product,
            //                                          (ClothesColor)SelectProductColor.SelectedItem,
            //                                          (Supplier)SelectProductSupplier.SelectedItem,
            //                                          (Category)SelectProductCategory.SelectedItem);
            ProductViewModel.ProductRepository.Create(ProductViewModel.Product);

        }
    }
}
