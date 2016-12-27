using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsole.Interfaces;
using BlackjackConsole.Models;

namespace BlackjackConsole
{
    class Customer:ICustomer
    {
        CustomerModel CustM;
        ConsoleOutput ConOut;
        public Customer()
        {
            CustM = new CustomerModel();
            ConOut = new ConsoleOutput();
        }
        //выбор к-ва денег у пользователя, которые он может поставить
        public void ChoiceBank()
        {
            int number;
            while (true) {
                ConOut.ChoiceMoney();
                bool result = Int32.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    CustM.customerBank = number;
                    return;
                }
            }
        }

        public void ChangeRate()
        {
            int number;
            while (true)
            {
                ConOut.ChoiceRate();
                bool result = Int32.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    if (number > CustM.customerBank)
                    {
                        ConOut.HigherRate();
                    }
                    else
                    {
                        CustM.currentRate = number;
                        return;
                    }
                }
            }
        }

        public int ChoiceValueOfAse()
        {
            while (true)
            {
                ConOut.ChoiceAce();
                var inputValue = Console.ReadLine();
                switch (inputValue)
                {
                    case "1":
                        return 1;
                    case "11":
                        return 11;
                    default:
                        ConOut.MakeChoice();
                        break;
                }
            }
        }
    }
}
