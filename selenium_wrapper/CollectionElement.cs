using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public abstract class CollectionElement : Element
    {
        public CollectionElement(string xpath, string xpath_item) : base(xpath)
        {
            ItemXPath = xpath_item;
        }

        public string ItemXPath { get; set; }
    }
}
