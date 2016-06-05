using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class Container4 : Container
    {
        public Input input = new Input("/input11");
        public Select select = new Select("/select", "/select_item");

        public Container4(string xpath) : base(xpath)
        {
        }
    }
}
