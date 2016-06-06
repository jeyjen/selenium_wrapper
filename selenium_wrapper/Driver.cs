using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public enum Browser
    {
        None,
        Firefox,
        Chrome,
        IE
    }


    public class Driver
    {
        private Session _session;
        private string _browser;
        private IWebDriver _selenium_driver;
        private Dictionary<Type, Page> _pages = new Dictionary<Type, Page>();

        internal Driver(Session session, string browser, int commandTimeout)
        {
            _session = session;
            _browser = browser.ToLower();
            switch (_browser)
            {
                case "ie":
                    {
                        var options = new InternetExplorerOptions
                        {
                            IgnoreZoomLevel = true
                        };
                        _selenium_driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(), options,TimeSpan.FromSeconds(commandTimeout));
                    } break;
                case "chrome":
                    {
                        
                    }break;
                case "firefox":
                    {

                    } break;
            }
        }

        public IWebElement FindElement(string _xpath)
        {
            return _selenium_driver.FindElement(By.XPath(_xpath));
        }

        public void Close()
        {
            _selenium_driver.Quit();
        }

        public T Navigate<T>(string url) where T :Page, new()
        {
            _selenium_driver.Navigate().GoToUrl(url);
            Page page = null;
            if (_pages.ContainsKey(typeof(T)))
            {
                page = _pages[typeof(T)];
            }
            else
            {
                page = new T();
                page._session = _session;
                page.Prepare();
            }
            page._handle = _selenium_driver.CurrentWindowHandle;
            if (page.IsPage())
            { }
            return (T)page;
        }

        public T Switch<T>() where T : Page, new()
        {
            // проверяет есть ли
            return new T();
        }

        /*
         void waitForLoad(WebDriver driver) {
    new WebDriverWait(driver, 30).until((ExpectedCondition<Boolean>) wd ->
            ((JavascriptExecutor) wd).executeScript("return document.readyState").equals("complete"));
}
         */

    }
}
