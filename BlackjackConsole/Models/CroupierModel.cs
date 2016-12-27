using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole.Models
{
    class CroupierModel
    {
        public List<string> CroupierCards { get; set; }
        public Dictionary<string, int> cardsValue = new Dictionary<string, int> { { "2",2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
            { "7", 7 }, { "8",8 },{ "9",9 }, { "10",10 }, { "J", 10 }, { "Q", 10 }, { "K",10 }, { "A",0 } };
    }
}
