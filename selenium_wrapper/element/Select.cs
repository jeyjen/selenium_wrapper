using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper.element
{
    public class Select : CollectionElement
    {
        public Select(string xpath, string xpath_item) : base(xpath, xpath_item)
        {
        }
    }
}
