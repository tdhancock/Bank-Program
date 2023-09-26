using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public interface IAccount
    {
        //public enum AccountState { }
        public string name { get; set; }
        public string address { get; set; }
        public string acc_number { get; set; }
        public decimal min_balance { get; set; }
        public int type { get; set; }
        public decimal serviceFee { get; set; }
        public void PayInFunds(decimal amount);
        public bool WithdrawFunds(decimal amount);
        public bool SetBalance(decimal inBalance);
        public decimal GetBalance();
        public void greeting();
        public void setState(string newState);
        public Account.AccountState getState();
        public string getType();
    }
}
