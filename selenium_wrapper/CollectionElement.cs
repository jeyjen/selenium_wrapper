using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public abstract class CollectionElement : Element
    {
        internal string _item_xpath;

        public CollectionElement(string xpath, string xpath_item) : base(xpath)
        {
            _item_xpath = xpath_item;
        }

        public string ItemXPath
        {
            get { return _item_xpath; }
        }
    }
}
