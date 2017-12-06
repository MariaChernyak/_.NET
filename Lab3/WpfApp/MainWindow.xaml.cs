using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitDataGrid();
        }

        private void InitDataGrid()
        {
            dataGrid.ItemsSource = App.Manager.GetList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int count;
            int.TryParse(txtCount.Text, out count);
            if (count == 0)
            {
                count = 10;
            }
            dataGrid.ItemsSource = App.Manager.GetList<object>(p =>p.Name, count);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow();
            addWindow.Closed += (o, args) => InitDataGrid();
            addWindow.Show();
        }
    }
}
