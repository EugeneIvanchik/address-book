using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book
{
    public class FirstGroupData
    {
        public string Name {get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public FirstGroupData (string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }
    }
}
