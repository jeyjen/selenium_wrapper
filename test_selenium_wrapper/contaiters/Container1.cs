using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class Container1: Container
    {
        public Input FirstName = new Input("/input1");
        public Input LastName = new Input("/input2");

        public Frame1 frame1 = new Frame1("/frame1");

        public Container1(string xpath):base(xpath)
        { 
        }
    }
}
