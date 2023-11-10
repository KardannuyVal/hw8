using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class BankTransaction
    {
        DateTime transaction_time { get; set; }

        readonly double money;

        public BankTransaction(double money)
        {
            transaction_time = DateTime.Now;
            this.money = money;
        }

        public string Print()
        {
            return ($"{transaction_time} произошла операция на сумму {money} рублей\n");
        }
    }
}
