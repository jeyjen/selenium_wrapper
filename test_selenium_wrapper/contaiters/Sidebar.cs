using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class Sidebar: Container
    {
        public Input FirstName = new Input("имя");
        public Input LastName = new Input("фамилия");

        public Sidebar(string xpath):base(xpath)
        { 
        }
    }
}
