using selenium_wrapper;
using selenium_wrapper.attribute;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_selenium_wrapper.contaiters;


namespace test_selenium_wrapper.pages
{
    [Name("Главная страница")]
    public class MainPage : Page
    {
        public Container1 container1 = new Container1("/container1");
        public Container3 container3 = new Container3("/container3");
        public Input input = new Input("/input6");

        public override bool IsPage(Driver driver)
        {
            return true;
        }
    }
}
