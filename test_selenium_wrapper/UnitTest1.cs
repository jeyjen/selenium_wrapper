using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_selenium_wrapper.pages;

namespace test_selenium_wrapper
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var main = new MainPage();
            main.Header.Login.Click();
            main.Header.Password.Click();
            main.Header.Login.SetText();
        }
    }
}
