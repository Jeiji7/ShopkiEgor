using Microsoft.Win32;
using ShopikEgorik.BDSHKA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Linq;

namespace ShopikEgorik.PagesWork
{
    /// <summary>
    /// Логика взаимодействия для MainMenu1.xaml
    /// </summary>
    public partial class MainMenu1 : Page
    {

        public MainMenu1()
        {
            InitializeComponent();
            FankoSalonList.ItemsSource = App.BD.Product.ToList();
            var type = App.BD.Type_Prod.ToList();
            type.Insert(0, new BDSHKA.Type_Prod() { ID_type = 0, Name_type = "Все" });
            TypeCB.ItemsSource = type.ToList();
            TypeCB.DisplayMemberPath = "Name_type";

            //var names = App.BD..ToList();
            //types.Insert(0, new BDSHKA1.TypeHair() { IDTypeHair = 0, NameTypeHair = "Все" });
            //TypeHairCB.ItemsSource = types.ToList();
            //TypeHairCB.DisplayMemberPath = "NameTypeHair";


            NameCB.ItemsSource = App.BD.Product.ToList();
            NameCB.DisplayMemberPath = "Name_prod";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Client client = new Client()
            {
                Name = NameClient.Text.Trim(),
                Surename = SurenameClient.Text.Trim(),
                City = CityTB.Text.Trim(),
                ID_prod = (NameCB.SelectedItem as Product).ID_prod
            };
            Connection.BD.Client.Add(client);
            Connection.BD.SaveChanges();
            MessageBox.Show("Заказ отправлен на обработку");

        }

        private void TypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = TypeCB.SelectedItem as Type_Prod;
            if(type.ID_type == 0)
            {
                FankoSalonList.ItemsSource = new List<Product>(Connection.BD.Product);
                NameCB.ItemsSource = Connection.BD.Product.ToList();
            }
                
            else 
            {
                FankoSalonList.ItemsSource = new List<Product>(Connection.BD.Product.Where(i => i.ID_type == type.ID_type));
                NameCB.ItemsSource = Connection.BD.Product.Where(j => j.ID_type == type.ID_type).ToList();
            }
        }

        private void NameCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var name = NameCB.SelectedItem as Product;
            var type = TypeCB.SelectedItem as Type_Prod;
            FankoSalonList.ItemsSource = Connection.BD.Product.Where(i => i.Name_prod == name.Name_prod).ToList();
        }

        private void SearchTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FankoSalonList.ItemsSource = new List<Product>(Connection.BD.Product.Where(i => i.Name_prod.StartsWith(SearchTBox.Text)));
        }
    }
}
