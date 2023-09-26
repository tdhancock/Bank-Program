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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            listAcc();
        }

        private void listAcc()
        {
            string newAccounts = "";
            Dictionary<string, IAccount> accounts = dictWrapper.getDict();
            List<string> keys = new List<string>(dictWrapper.getDict().Keys);
            foreach (string res in keys)
            {
                newAccounts += $"Name: {res} - Account Number: {accounts[res].acc_number} - Type: {accounts[res].getType()} Account\n";
            }
            accountList.Text = newAccounts;
        }

        private void selectAccount(object sender, RoutedEventArgs e)
        {
            string choice = selection.Text;
            Dictionary<string, IAccount> accounts = dictWrapper.getDict();
            if (accounts.ContainsKey(choice))
            {
                IAccount currObj = accounts[choice];
                string moreText = "";
                moreText += $"Name: {currObj.name}\nAccount Number: {currObj.acc_number}\nAddress: {currObj.address}\n" +
                    $"Balance: ${currObj.GetBalance()}\nAccount State: {currObj.getState()}\n" +
                    $"Account Type: {currObj.getType()}";
                moreInfo.Text = moreText;
                cantFind.Visibility = Visibility.Hidden;
            }
            else
            {
                cantFind.Visibility = Visibility.Visible;
                cantFind.Text = $"Can't find an account with name: {choice}";
            }
        }
    }
}
