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
        public SearchForm search = new SearchForm("//form[@id='tsf']");

        public override bool IsPage()
        {
            return true;
        }
    }
}
