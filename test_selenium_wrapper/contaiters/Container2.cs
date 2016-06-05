using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class Container2: Container
    {
        public Input input = new Input("/input3");

        public Container2(string xpath) : base(xpath)
        { }
    }
}
