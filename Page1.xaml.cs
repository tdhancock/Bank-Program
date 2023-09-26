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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void createSavingsAccount(object sender, RoutedEventArgs e)
        {
            showFields("Savings");
        }

        private void createCheckingAccount(object sender, RoutedEventArgs e)
        {
            showFields("Checking");
        }

        private void createCDAccount(object sender, RoutedEventArgs e)
        {
            showFields("CD");
        }

        private void showFields(string type)
        {
            accName.Visibility = Visibility.Visible;
            accAddress.Visibility = Visibility.Visible;
            accBalance.Visibility = Visibility.Visible;
            accType.Visibility = Visibility.Visible;
            submitBtn.Visibility = Visibility.Visible;
            accType.Text = type;
        }

        private void submitAcc(object sender, RoutedEventArgs e)
        {
            bool submit = true;
            string userName = accName.Text;
            if (Regex.IsMatch(userName, @"^[a-zA-Z\s*]+$"))
            {
                //hide error message
                accNameError.Visibility = Visibility.Hidden;
            }
            else
            {
                //show error message
                accNameError.Visibility = Visibility.Visible;
                submit = false;
            }
            string userAddress = accAddress.Text;
            if (Regex.IsMatch(userAddress, @"^[a-zA-Z0-9\s*]+$"))
            {
                accAddressError.Visibility = Visibility.Hidden;
            }
            else
            {
                accAddressError.Visibility = Visibility.Visible;
                submit = false;
            }
            string balance = accBalance.Text;
            if (Regex.IsMatch(balance, @"^\d+$"))
            {
                if (validBalance(balance, accType.Text) != false)
                {
                    accBalanceError.Visibility = Visibility.Hidden;
                }
                else
                {
                    accBalanceError.Visibility = Visibility.Visible; 
                    submit = false;
                }
            }
            else
            {
                accBalanceError.Visibility = Visibility.Visible;
                submit = false;
            }
            if(submit != false)
            {
                decimal newBalance = Convert.ToDecimal(balance);
                bool success = Program.createAccount(userName, userAddress, newBalance, accType.Text);
                if (success)
                {
                    accountInfo.Visibility = Visibility.Visible;
                    accountInfo.Background = Brushes.White;
                    accountInfo.Text = $"Account with account number {dictWrapper.getDict()[accName.Text].acc_number} has been created! Service fee of ${dictWrapper.getDict()[accName.Text].serviceFee} applied";
                }
                else
                {
                    accountInfo.Visibility = Visibility.Visible;
                    accountInfo.Background = Brushes.Red;
                    accountInfo.Text = $"Account with {accName.Text} already exists! Please change the name.";
                }
            }
        }

        private bool validBalance(string balance, string type)
        {
            if(type == "Savings")
            {
                if (Convert.ToDecimal(balance) < 100)
                {
                    return false;
                }
                else return true;
            }
            if (type == "Checking")
            {
                if (Convert.ToDecimal(balance) < 10)
                {
                    return false;
                }
                else return true;
            }
            if (type == "CD")
            {
                if (Convert.ToDecimal(balance) < 500)
                {
                    return false;
                }
                else return true;
            }
            return false;
        }

    }
}
