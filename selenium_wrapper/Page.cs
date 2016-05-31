using OpenQA.Selenium;
using System;

namespace selenium_wrapper
{
    public abstract class Page
    {
        public Page()
        { }
        public abstract bool IsPage(Driver driver);

        // Реализовать проверку присутсвия элементов на странице
        
    }
}
