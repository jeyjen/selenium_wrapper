using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper.attribute
{
    class ElementAttribute : Attribute
    {
        private string _name;
        public ElementAttribute(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
