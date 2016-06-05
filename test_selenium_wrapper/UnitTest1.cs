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
            main.container1.frame1.container2.input.Click();
            

            var select = main.container3.frame2.container4.select;
            select.Click();
            /*
             не очистились фреймы два вместо одного у элемента

             */
        }
    }
}
