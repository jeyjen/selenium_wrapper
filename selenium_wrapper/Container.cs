using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public class Container : UIElement
    {
        public Container()
        {
            _xpath = "";
        }

        public Container(string xpath)
        {
            _xpath = xpath == null? "": xpath;
        }
    }
}
