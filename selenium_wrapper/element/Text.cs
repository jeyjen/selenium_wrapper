using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper.element
{
    public class Text : Element
    {
        public Text(string xpath, string name = "") : base(xpath, name)
        {
        }
    }
}
