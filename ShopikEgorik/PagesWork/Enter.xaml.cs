using ShopikEgorik.BDSHKA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopikEgorik.PagesWork
{
    /// <summary>
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    public partial class Enter : Page
    {
        public static List<Employee> worker { get; set; }
        public Enter()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = LoginTB.Text.Trim();
            string password = PasswordPB.Password.Trim();

            worker = new List<Employee>(Connection.BD.Employee.ToList());
            Employee currentUser = worker.FirstOrDefault(x => x.Login == name && x.Password == password);
            if (currentUser != null)
                NavigationService.Navigate(new Dobavka());
            else
                MessageBox.Show("Все !верно");
        }
    }
}
