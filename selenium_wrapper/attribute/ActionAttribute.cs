using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper.attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    class ActionAttribute : Attribute
    {
        private string _name;
        public ActionAttribute(string name)
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
