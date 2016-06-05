using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public class Container
    {
        public string XPath { get; set; }
        public Frame[] Frames { get; set; }
        
        public Container(string xpath)
        {
            this.XPath = xpath;
        }
    }
}
