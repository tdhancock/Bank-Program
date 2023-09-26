using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Random _random = new Random();
            string userAccountNum = _random.Next(100000, 300000).ToString();
            IAccount rudy = new checkingAccount("Rudy", "Jazz lane", userAccountNum, 1000000);
            rudy.type = 1;
            userAccountNum = _random.Next(100000, 300000).ToString();
            IAccount luka = new savingsAccount("Luka", "Mavericks lane", userAccountNum, 2000000);
            luka.type = 2;
            userAccountNum = _random.Next(100000, 300000).ToString();
            IAccount zion = new CDAccount("Zion", "Pelicans lane", userAccountNum, 3000000);
            zion.type = 3;
            dictWrapper.addItem(rudy);
            dictWrapper.addItem(luka);
            dictWrapper.addItem(zion);

        }

        private void AddAccount(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1();
        }

        private void FindAccount(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
            //Page2.listAccounts.listAcc();
        }

        private void manageAccount(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page4();
        }

    }

    public static class dictWrapper
    {
        public static Dictionary<string, IAccount> AccountDict = new Dictionary<string, IAccount>();

        public static void addItem(IAccount obj)
        {
            AccountDict.Add(obj.name, obj);
        }

        public static Dictionary<string, IAccount> getDict()
        {
            return AccountDict;
        }

        public static IAccount returnAccount(string name)
        {
            return AccountDict[name];
        }
    }
}

    