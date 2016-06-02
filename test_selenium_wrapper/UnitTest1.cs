using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_selenium_wrapper.pages;
using selenium_wrapper;

namespace test_selenium_wrapper
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Реализовать атрибут для описания кейса
            
            //Driver driver =Driver.Instance();
            //var main = driver.Navigate<MainPage>("url");
            //main = driver.Switch<MainPage>();
            var main = new MainPage();
            main.header.Login.Click();
            main.header.Password.Click();
            main.header.Login.SetText();

            main.footer.div.input.Click();

        }
    }
}
