using System;
using System.Linq;
using System.Windows;
using DL.Model;

namespace WpfApp
{
    /// <summary>
    ///     Interaction logic for Add.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            InitComboBoxRaiting();
        }

        private void InitComboBoxRaiting()
        {
            comboBoxRaiting.ItemsSource = Enumerable.Range(1, 5);
            comboBoxRaiting.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var student = new StudentReport
            {
                Name = txtBoxName.Text,
                LastName = txtBoxLastName.Text,
                TestDate = datePicker.SelectedDate?.Date ?? DateTime.Now,
                TestName = txtBoxTestName.Text,
                Raiting = (int) comboBoxRaiting.SelectedValue
            };
            App.Manager.Add(student);
            Close();
        }
    }
}