using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class Div: Container
    {
        public Input input = new Input("");
        public Div(string xpath) : base(xpath)
        { }
    }
}
