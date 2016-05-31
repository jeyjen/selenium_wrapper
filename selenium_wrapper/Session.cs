using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public class Session
    {
        public class AddInfo
        {
            public string XPath { get; set; }
            public string[] Frames { get; set; }
            // Последовательно переключиться в каждый из фреймов

        }

        public Dictionary<string, AddInfo> _sessionElements = new Dictionary<string, AddInfo>();

        public Driver Driver {get;set;}
        
    }
}
