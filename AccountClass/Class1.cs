using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClass
{
    public class AccountEventArgs
    {
        // Сообщение
        public string Message { get; }
        // Сумма, на которую изменился счет
        public int Sum { get; }
        public AccountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }
    public class Account
    {
        public delegate void AccountDelegate(Account sender, AccountEventArgs e);
        public delegate void AccountEvent(Account sender, AccountEventArgs e);
        public event AccountEvent Notify;
        AccountDelegate taken;

        public string fio;
        public int sum;
        
        private string Fio { get => fio; set => fio = value; }
        private int Sum { get => sum; set => sum = value; }
        public void RegisterHandler(AccountDelegate del)
        {
            taken = del;
        }

        public Account(string fio, int sum)
        {
            Fio = fio;
            Sum = sum;
        }
        public void Put(int sum)
        {
            taken?.Invoke($"Сумма {sum} снята со счета");
            Sum += sum;
            Notify?.Invoke(this, new AccountEventArgs($"На счет поступило {sum}", sum));
        }
        public void Add(int sum) => this.Sum += sum;

        public void Take(int sum)
        {
            if (this.Sum >= sum)
            {
                this.Sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke(($"Сумма {sum} снята со счета", sum));
                Notify?.Invoke(this, new AccountEventArgs($"Сумма {sum} снята со счета", sum));
            }
            else
            {
                taken?.Invoke(("Недостаточно денег на счете", sum));
                Notify?.Invoke(this, new AccountEventArgs("Недостаточно денег на счете", sum));
            }
        }

    }
}
