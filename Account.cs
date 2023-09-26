using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    abstract public class Account : IAccount

    {
        public Account(string name, string address, string acc_number, decimal balance)
        {
            // create an Account instance
            this.name = name;
            this.address = address;
            this.acc_number = acc_number;
            this.state = AccountState.New;
            this.min_balance = 100;
            if (balance < min_balance)
            {
                throw new ArgumentException($"The initial balance must be >= {min_balance}");
            }

            this.SetBalance(balance);
        }
        public enum AccountState
        {
            New, Active, underAudit, Frozen, Closed
        }

        public string name { get; set; }
        public string address { get; set; }
        public string acc_number { get; set; }
        public decimal balance;
        public abstract decimal min_balance { get; set; }
        public abstract decimal serviceFee { get; set; }

        public int type { get; set; }

        private AccountState state;

        public void PayInFunds(decimal amount)
        {
            // add more funds
            this.SetBalance(this.balance + amount);
        }

        public bool WithdrawFunds(decimal amount)
        {
            //withdraw funds
            if ((this.balance - amount) < 0)
            {
                this.balance -= amount;
                return false;
            }
            else
            {
                this.balance -= amount;
                return true;
            }
        }

        public bool SetBalance(decimal inBalance)
        {
            //set the balance 
            if (inBalance < 100)
            {
                return false;
            }
            else
            {
                this.balance = inBalance;
                return true;
            }
        }

        public decimal GetBalance()
        {
            // return the balance
            return this.balance;
        }

        public void greeting()
        {
            //Greeting to print out some of the values: Not required by lab requirements
            Console.WriteLine(name + address + balance + acc_number);
        }

        public void setState(string newState)
        {
            // set the state
            string[] states = { "New", "Frozen", "Active", "underAudit", "Closed" };
            if (newState == states[0])
            {
                this.state = AccountState.New;
            }
            if (newState == states[1])
            {
                this.state = AccountState.Frozen;
            }
            if (newState == states[2])
            {
                this.state = AccountState.Active;
            }
            if (newState == states[3])
            { 
                this.state = AccountState.underAudit;
            }
            if (newState == states[4])
            {
                this.state = AccountState.Closed;
            }
        }
        public AccountState getState()
        {
            //return the state
            return this.state;
        }

        public string getType()
        {
            if(this.type == 1)
            {
                return "Checking";
            }
            if(this.type == 2)
            {
                return "Savings";
            }
            if(this.type == 3)
            {
                return "CD";
            }
            else
            {
                return "No type specified";
            }
        }

    }

}