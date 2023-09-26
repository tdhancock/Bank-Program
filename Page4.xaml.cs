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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void manageUser(object sender, RoutedEventArgs e)
        {
            //displaySelection
            string choice = userSelection.Text;
            Dictionary<string, IAccount> accounts = dictWrapper.getDict();
            if (accounts.ContainsKey(choice))
            {
                displaySelection.Visibility = Visibility.Visible;
                viewInfo.Visibility = Visibility.Visible;
                deposit.Visibility = Visibility.Visible;
                withdraw.Visibility = Visibility.Visible;
                setState.Visibility = Visibility.Visible;
                displaySelection.Text = $"You have chosen {accounts[choice].name}. Select what actions to take below. ";
            }
        }

        private void depositMoney(object sender, RoutedEventArgs e)
        {
            desc.Visibility = Visibility.Visible;
            userInput.Visibility = Visibility.Visible;
            confirmation.Visibility = Visibility.Visible;
            desc.Text = "Enter amount to deposit below";
        }

        private void withdrawMoney(object sender, RoutedEventArgs e)
        {
            desc.Visibility = Visibility.Visible;
            userInput.Visibility = Visibility.Visible;
            confirmation.Visibility = Visibility.Visible;
            desc.Text = "Enter amount to withdraw below";
        }

        private void accState(object sender, RoutedEventArgs e)
        {
            desc.Visibility = Visibility.Visible;
            userInput.Visibility = Visibility.Visible;
            confirmation.Visibility = Visibility.Visible;
            desc.Text = "Enter new state below. Choices are (New, Active, Frozen, underAudit, Closed)";
        }

        private void viewUserInfo(object sender, RoutedEventArgs e)
        {
            Dictionary<string, IAccount> accounts = dictWrapper.getDict();
            IAccount currObj = accounts[userSelection.Text];
            display.Visibility = Visibility.Visible;
            string moreText = "";
            moreText += $"Name: {currObj.name}\nAccount Number: {currObj.acc_number}\nAddress: {currObj.address}\n" +
                $"Balance: ${currObj.GetBalance()}\nAccount State: {currObj.getState()}\n" +
                $"Account Type: {currObj.getType()}";
            display.Text = moreText;
        }

        private void confirmSelection(object sender, RoutedEventArgs e)
        {
            Dictionary<string, IAccount> accounts = dictWrapper.getDict();
            IAccount currObj = accounts[userSelection.Text];
            string userChoice = userInput.Text;
            string decision = desc.Text;
            if("Enter amount to deposit below" == decision)
            {
                if (Regex.IsMatch(userChoice, @"^\d+$"))
                {
                    //hide error message
                    incorrect.Visibility = Visibility.Hidden;
                    currObj.PayInFunds(Convert.ToDecimal(userChoice));
                    display.Visibility = Visibility.Visible;
                    display.Text = $"${userChoice} deposited in {currObj.name} account. Current balance is ${currObj.GetBalance()}";
                }
                else
                {
                    //show error message
                    incorrect.Visibility = Visibility.Visible;
                }
            }
            if ("Enter amount to withdraw below" == decision)
            {
                if (Regex.IsMatch(userChoice, @"^\d+$"))
                {
                    //hide error message
                    incorrect.Visibility = Visibility.Hidden;
                    if (currObj.GetBalance() - Convert.ToDecimal(userChoice) > 0)
                    {
                        currObj.WithdrawFunds(Convert.ToDecimal(userChoice));
                        display.Visibility = Visibility.Visible;
                        display.Text = $"${userChoice} withdrawn from {currObj.name} account. Current balance is ${currObj.GetBalance()}";
                    }
                    else
                    {
                        display.Visibility = Visibility.Visible;
                        display.Text = $"Withdrawing ${userChoice} would take this account below $0, please choose a different amount.";
                    }
                }
                else
                {
                    //show error message
                    incorrect.Visibility = Visibility.Visible;
                }

            }
            if ("Enter new state below. Choices are (New, Active, Frozen, underAudit, Closed)" == decision)
            {
                if(userChoice == "New" || userChoice == "Active" || userChoice == "Frozen" || userChoice == "underAudit" || userChoice == "Closed")
                {
                    currObj.setState(userChoice);
                    incorrect.Visibility = Visibility.Hidden;
                    display.Visibility = Visibility.Visible;
                    display.Text = $"You set account state to {currObj.getState()}";
                }
                else
                {
                    incorrect.Visibility = Visibility.Visible;
                    display.Visibility = Visibility.Visible;
                    display.Text = $"Not a valid state, please choose from the list above.";
                }
                
            }
        }
    }
}
