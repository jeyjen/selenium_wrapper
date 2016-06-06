using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class SearchForm: Container
    {
        public Text search_line = new Text(
            "//input[@id='lst-ib']", 
            "строка поиска");
        public Button search = new Button(
            "//button[@value='Поиск']", 
            "поиск");
        public Button happy = new Button(
            "//input[@value='Мне повезёт!']", 
            "мне повезет");

        public SearchForm(string xpath):base(xpath)
        { 
        }
    }
}
