using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public class Frame
    {
        public string XPath { get; set; }

        public Frame(string xpath)
        {
            XPath = xpath;
        }
    }
}
