using selenium_wrapper;
using selenium_wrapper.attribute;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    [Frame]
    public class Frame1 : Container
    {
        public Container2 container2 = new Container2("/container2");
        public Input input = new Input("/input4");
        public Frame1(string xpath):base(xpath)
        {
        }
    }
}
