using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsole.Interfaces;

namespace BlackjackConsole
{
    class Customer:ICustomer
    {
        public int customerBank { get; set; }
        public int currentRate { get; set; }
        public List<string> customerCards { get; set; }

        //выбор к-ва денег у пользователя, которые он может поставить
        public void ChoiceBank()
        {
            int number;
            while (true) {
                Console.WriteLine("Choice amount of your money");
                bool result = Int32.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    customerBank = number;
                    return;
                }
            }
        }

        public void ChangeRate()
        {
            int number;
            while (true)
            {
                Console.WriteLine("Choice your rate");
                bool result = Int32.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    if (number > customerBank)
                    {
                        Console.WriteLine("Your rate higher then your bank");
                    }
                    else
                    {
                        currentRate = number;
                        return;
                    }
                }
            }
        }

        public int ChoiceValueOfAse()
        {
            while (true)
            {
                Console.WriteLine("Choice value of Ace\n1 or 11");
                var inputValue = Console.ReadLine();
                switch (inputValue)
                {
                    case "1":
                        return 1;
                    case "11":
                        return 11;
                    default:
                        Console.WriteLine("Make a choise");
                        break;
                }
            }
        }
    }
}
