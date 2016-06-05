using selenium_wrapper;
using selenium_wrapper.attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    [Frame]
    public class Frame2 : Container
    {
        public Container4 container4 = new Container4("container4");

        public Frame2(string xpath) : base(xpath)
        {

        }
    }
}
