using Microsoft.Win32;
using ShopikEgorik.BDSHKA;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Dobavka.xaml
    /// </summary>
    public partial class Dobavka : Page
    {
        public Dobavka()
        {
            InitializeComponent();
            var typee = App.BD.Type_Prod.ToList();
            //typee.Insert(0, new BDSHKA.Type_Prod() { ID_type = 0, Name_type = "Все" });
            TypeCBDob.ItemsSource = typee.ToList();
            TypeCBDob.DisplayMemberPath = "Name_type";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product prod = new Product() 
            {
                Name_prod = NameTB.Text.Trim(),
                ID_type = (TypeCBDob.SelectedItem as Type_Prod).ID_type,
                Price = Convert.ToDecimal(PriseTB.Text.Trim())
            };
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
                };
                if (openFileDialog.ShowDialog().GetValueOrDefault())
                {
                    prod.Image_prod = File.ReadAllBytes(openFileDialog.FileName);
                    TestImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    
                    Connection.BD.Product.Add(prod);
                    Connection.BD.SaveChanges();
                }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagesWork.MainMenu1());
        }
    }
}
