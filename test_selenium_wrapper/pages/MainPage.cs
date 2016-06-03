using selenium_wrapper;
using selenium_wrapper.attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_selenium_wrapper.contaiters;
using test_selenium_wrapper.frames;

namespace test_selenium_wrapper.pages
{
    [Name("Главная страница")]
    public class MainPage : Page
    {
        public Header header = new Header("p1");
        public Footer footer = new Footer("footer");
        public ContentFrame content = new ContentFrame("content");
        public override bool IsPage(Driver driver)
        {
            return true;
        }
    }
}
