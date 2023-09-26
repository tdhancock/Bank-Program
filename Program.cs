// See https://aka.ms/new-console-template for more informationusing Console;
// Lab 04 Banking Program
// Name: Tanner Hancock
// CS3260 Section X01
// Project: Lab_04
// Date: 07/26/2022
// Purpose: Create a simple banking structure with GUI
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Lab4
{
    public class Program
    {

        public static bool createAccount(string userName, string userAccount, decimal balance, string type)
        {
            if (dictWrapper.getDict().ContainsKey(userName))
            {
                return false;
            }
            Random _random = new Random();
            string userAccountNum = _random.Next(100000, 300000).ToString();
            if (type == "Savings")
            {
                IAccount account = new savingsAccount(userName,userAccount,userAccountNum,balance);
                dictWrapper.addItem(account);
                return true;
            }
            if (type == "Checking")
            {
                IAccount account = new checkingAccount(userName, userAccount,userAccountNum, balance);
                dictWrapper.addItem(account);
                return true;
            }
            if (type == "CD")
            {
                IAccount account = new CDAccount(userName, userAccount, userAccountNum,balance);
                dictWrapper.addItem(account);
                return true;
            }
            return false;
        }

        public static void listAccounts()
        {

        }
        public static void management(string name)
        {
            
        }

        public static string startProgram()
        {
            string userInput = null;
            while (userInput != "1" && userInput != "2" && userInput != "7")
            {
                Console.WriteLine("\nWelcome to UVU Banking. Select an option below.\nType 1 to create a new Account, Type 2 to find an account, or Type 7 to quit. ");
                userInput = Console.ReadLine();
                if(userInput != "1" && userInput != "2" && userInput != "7")
                {
                    Console.WriteLine("\nPlease choose an option from the list!\n");
                }
            }
            return userInput;
        }

        static void findAccount(Dictionary<string, IAccount> AccountDict)
        {
            while (true)
            {
                Console.WriteLine("\nPlease select which account you want from the list below.");
                List<string> keys = new List<string>(AccountDict.Keys);
                Console.WriteLine("\nDisplaying keys...");
                foreach (string res in keys)
                {
                    Console.WriteLine(res + " - " + AccountDict[res].getType());
                }
                Console.WriteLine("\n");
                string userSelection = Console.ReadLine();
                if (AccountDict.ContainsKey(userSelection))
                {
                    IAccount currObj = AccountDict[userSelection];
                    while (true)
                    {
                        Console.WriteLine($"\nYou have chosen {currObj.name} account. Please select what to do next:\nType 1 to view account information\nType 2 to manage account\nType 7 to return to Previous Menu");
                        userSelection = Console.ReadLine();
                        if(userSelection == "1")
                        {
                            Console.WriteLine($"\nAccount Name: {currObj.name}\nAccount Address: {currObj.address}\nAccount Number: {currObj.acc_number}\nAccount Balance: ${currObj.GetBalance()}\nAccount Type: {currObj.getType()}\nAccount state: {currObj.getState()}\n");
                        }
                        else if(userSelection == "2")
                        {
                            manageAccount(currObj);
                        }
                        else if(userSelection == "7")
                        {
                            break;
                        }
                    }
                    break;
                    
                }
                else
                {
                    Console.WriteLine("\nNo such account exists, please choose from the list of keys provided");
                }
            } 
        }

        static void manageAccount(IAccount currObj)
        {
            while (true)
            {
                Console.WriteLine("\nPlease choose an action, or enter 7 to return to previous menu.\n\nEnter 1 to make a Deposit\nEnter 2 to Withdraw Funds\n" +
                    "Enter 3 to Check Balance\nEnter 4 to set Account State\nEnter 5 to view Account information\n");
                string selection = Console.ReadLine();
                if(selection == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("\nPlease enter amount to deposit: ");
                        string placeholder = Console.ReadLine();
                        decimal amount;
                        if (Regex.IsMatch(placeholder, @"^\d+$"))
                        {
                            amount = decimal.Parse(placeholder);
                            currObj.PayInFunds(amount);
                            Console.WriteLine($"\nNew Balance is ${currObj.GetBalance()}\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nAmount entered was not valid, please use only numbers");
                        }
                    }
                }
                else if(selection == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("\nPlease enter amount to withdraw: ");
                        string placeholder = Console.ReadLine();
                        decimal amount;
                        if (Regex.IsMatch(placeholder, @"^\d+$"))
                        {
                            amount = decimal.Parse(placeholder);
                            if (currObj.GetBalance() - amount < 0)
                            {
                                Console.WriteLine($"\nCannot withdraw more money than is in the account, you can only withdraw up to ${currObj.GetBalance()}");
                            }
                            else
                            {
                                currObj.WithdrawFunds(amount);
                                Console.WriteLine($"\nNew Balance is ${currObj.GetBalance()}\n");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nAmount entered was not valid, please use only numbers");
                        }
                    }

                }
                else if(selection == "3")
                {
                    Console.WriteLine($"\nBalance is ${currObj.GetBalance()}\n");
                }
                else if(selection == "4")
                {
                    while (true)
                    {
                        Console.WriteLine("Please choose a new account state. (New, Active, Frozen, underAudit, Closed)");
                        string state = Console.ReadLine();
                        if (state == "New")
                        {
                            currObj.setState("New");
                            Console.WriteLine($"New State is {currObj.getState()}");
                            break;
                        }
                        else if (state == "Active")
                        {
                            currObj.setState("Active");
                            Console.WriteLine($"New State is {currObj.getState()}");
                            break;
                        }
                        else if (state == "Frozen")
                        {
                            currObj.setState("Frozen");
                            Console.WriteLine($"New State is {currObj.getState()}");
                            break;
                        }
                        else if (state == "underAudit")
                        {
                            currObj.setState("underAudit");
                            Console.WriteLine($"New State is {currObj.getState()}");
                            break;
                        }
                        else if (state == "Closed")
                        {
                            currObj.setState("Closed");
                            Console.WriteLine($"New State is {currObj.getState()}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter a valid state\n");
                        }
                    }
                }
                else if(selection == "7")
                {
                    break;
                }
                else if(selection == "5")
                {
                    Console.WriteLine($"\nAccount Name: {currObj.name}\nAccount Address: {currObj.address}\nAccount Number: {currObj.acc_number}\nAccount Balance: ${currObj.GetBalance()}\nAccount type: {currObj.getType()}\nAccount state: {currObj.getState()}\n");
                }
                else
                {
                    Console.WriteLine("Please enter a valid command");
                }
            }   
        }

    }

}
 