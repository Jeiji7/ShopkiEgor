using ShopikEgorik.BDSHKA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShopikEgorik
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static FankoEgorShopEntities BD = new FankoEgorShopEntities();
        //public static Worker Enter;
    }
}
