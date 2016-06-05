using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class Container3 : Container
    {
        public Input input = new Input("/input8");
        public Frame2 frame2 = new Frame2("/frame2");

        public Container3(string xpath) : base(xpath)
        { }
    }
}
