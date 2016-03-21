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
using Clothes.Data;
using Clothes.Models.ModelsDTO;

namespace ClothesWPF
{
    /// <summary>
    /// Interaction logic for EditQuantityWindow.xaml
    /// </summary>
    public partial class EditQuantityWindow : Window
    {
        public int Quantity { get; set; }

        public ProductDTO Product { get; set; }

        public ProductRepository Repository { get; set; }        

        public EditQuantityWindow(ProductDTO product)
        {
            this.Product = new ProductDTO();
            this.Product = product;
            InitializeComponent();
            this.Repository = new ProductRepository();
            this.Quantity = this.Product.Quantity;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            //ToDo       
            //var product = new ProductDTO();     
            this.Quantity = int.Parse(EditQuantityTextBox.Text);
            this.Product.Quantity = this.Quantity;
            Repository.Update(Product);
        }
    }
}
