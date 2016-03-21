namespace ClothesWPF
{
    using System.Data.Entity;
    using System.Windows;
    using Clothes.Data;
    using Clothes.Data.Migrations;
    using Clothes.Models;
    using Clothes.Models.ModelsDTO;
    using ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }        

        public MainWindow()
        {
            InitializeComponent();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClothesDbContext,Configuration>());
            MappingConfigurations.RegisterMappings();
            ViewModel = new MainWindowViewModel();
          
            //AddProductWindow.Closed += AddProductWindow_Closed;
            this.DataContext = ViewModel;
        }

        //private void AddProductWindow_Closed(object sender, System.EventArgs e)
        //{
        //    ViewModel.Products.Clear();
        //    this.ViewModel.Products = ViewModel.Repository.ReadAll();
        //}

        private void AddNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewProductWindow AddProductWindow = new AddNewProductWindow();
            AddProductWindow.ShowDialog();
        }

        private void AddNewCategoriesAndColors_Click(object sender, RoutedEventArgs e)
        {
            CategoriesColorsAndSuppliersWindow CategoriesWindow = new CategoriesColorsAndSuppliersWindow();
            CategoriesWindow.ShowDialog();
        }

        private void CurrentInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            StockWindow CurrentStockWindow = new StockWindow();
            CurrentStockWindow.ShowDialog();
        }
    }
}
