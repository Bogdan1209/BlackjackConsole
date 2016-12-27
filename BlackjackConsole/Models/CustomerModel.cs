using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole.Models
{
    class CustomerModel
    {
        public int customerBank { get; set; }
        public int currentRate { get; set; }
        public List<string> customerCards { get; set; }
    }
}
