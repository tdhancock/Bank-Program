using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class checkingAccount : Account
    {

        public checkingAccount(string name, string address, string acc_number, decimal balance) : base(name, address, acc_number, balance)
        {
            this.name = name;
            this.address = address;
            this.acc_number = acc_number + "C";
            this.min_balance = 10;
            this.serviceFee = 5;
            this.type = 1;
            if (balance < min_balance)
            {
                throw new ArgumentException($"The initial balance must be >= {min_balance}");
            }

            this.SetBalance(balance);
            this.balance -= serviceFee;
        }

        public override decimal min_balance { get; set; }
        public override decimal serviceFee { get; set; } = 5;
    }
}
