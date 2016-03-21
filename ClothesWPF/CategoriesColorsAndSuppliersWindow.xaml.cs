using Clothes.Models;
using ClothesWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using ClothesWPF.Model;
using Clothes.Data;
using Clothes.Models.ModelsDTO;

namespace ClothesWPF
{
    /// <summary>
    /// Interaction logic for CategoriesColorsAndSuppliersWindow.xaml
    /// </summary>
    public partial class CategoriesColorsAndSuppliersWindow : Window
    {

        private CategoriesColorsAndSupplierViewModel viewModel = new CategoriesColorsAndSupplierViewModel();

        //public Models models { get; set; }

        public CategoriesColorsAndSuppliersWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void AddCategoryButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Category.Name = AddNewCategory.Text;
            viewModel.AddCategory();
        }

        private void DeleteCategoryButtonClick(object sender, RoutedEventArgs e)
        {
            var deletedCategory = (CategoryDTO)ListViewCategories.SelectedItem;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(string.Format("Искате ли да изтриете категорията {0}?", deletedCategory.Name) , "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)  // error is here
            {
                viewModel.CategoryRepository.Delete(deletedCategory);
                viewModel.Categories.Remove(deletedCategory);
            }

        }

        private void AddSuppierButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Supplier.Name = AddNewSupplier.Text;
            viewModel.AddSupplier();
        }

        private void DeleteSupplierButtonClick(object sender, RoutedEventArgs e)
        {
            var deletedSupplier = (SupplierDTO)ListViewSupplier.SelectedItem;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(string.Format("Искате ли да изтриете доставчикът {0}?", deletedSupplier.Name), "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                viewModel.SupplierRepository.Delete(deletedSupplier);
                viewModel.Suppliers.Remove(deletedSupplier);
            }
        }

        private void AddColorButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Color.Name = AddNewColor.Text;
            viewModel.AddColor();
        }

        private void DeleteColorButtonClick(object sender, RoutedEventArgs e)
        {
            var deletedColor = (ClothesColorDTO)ListViewColors.SelectedItem;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(string.Format("Искате ли да изтриете цветът {0}?", deletedColor.Name) , "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                viewModel.ColorRepository.Delete(deletedColor);
                viewModel.Colors.Remove(deletedColor);
            }
        }
    }
}
