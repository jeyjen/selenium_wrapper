using selenium_wrapper;
using selenium_wrapper.attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.pages
{
    [Page("Главная страница")]
    public class MainPage : Page
    {
        public Header Header = new Header("");

        public override bool IsPage(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
