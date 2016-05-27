using OpenQA.Selenium;
using System;

namespace selenium_wrapper
{
    public abstract class Page
    {
        /// <summary>
        /// проверяет то что 
        /// </summary>
        /// <returns></returns>
        public abstract bool CheckPage(IWebDriver driver);

        /// <summary>
        /// проверяет наличие обязательных полей на странице
        /// </summary>
        public void CheckRequiredElements()
        {
            // Рефлексией получить набор полей являющиеся обязательными
            // Причем рекурсивно
        }
        
    }
}
