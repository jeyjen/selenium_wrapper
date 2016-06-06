using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_selenium_wrapper.pages;
using selenium_wrapper;

namespace test_selenium_wrapper
{
    [TestClass]
    public class UnitTest1
    {
        Session session = new Session();
        [TestMethod]
        public void t1()
        {
            // Реализовать атрибут для описания кейса
            
            var main = session.Driver.Navigate<MainPage>("www.google.com");
            main.search.search_line.SetText("hello google");
            main.search.search.Click();
            session.Driver.Close();
            /*
             не очистились фреймы два вместо одного у элемента

             */
        }
        [TestMethod]
        public void t2()
        {
        }
    }
}
