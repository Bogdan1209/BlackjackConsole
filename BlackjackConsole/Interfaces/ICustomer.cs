using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole.Interfaces
{
    interface ICustomer
    {
        int customerBank { get; set; }
        int currentRate { get; set; }
        List<string> customerCards { get; set; }
        void ChoiceBank();
        void ChangeRate();
        int ChoiceValueOfAse();

    }
}
