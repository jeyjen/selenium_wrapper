using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    

    public class Session
    {
        private SessionSettingsConfigSection _settings;
        private Driver _driver;

        public Session()
        {
            _settings = (SessionSettingsConfigSection)ConfigurationManager.GetSection("SessionSettings");
        }

       
        public Driver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new Driver(this, _settings.Driver.Browser, _settings.Driver.CommandTimeout);
                }
                return _driver;
            }
        }

        public void Close()
        {
            _driver.Close();
        }

        #region на реализацию
        public object TestData { get; set; }

        public object Log { get; }

        #endregion





        // передавать первоначальные настройки и набор смоуктестов в сессию
        // Сессия прогоняет набор смоуктестов и если все они прошли
        // Запускает начинается выполнение основного теста

        // для обеспечения единственности создания элементов объектов страниц
        // создать словарь с страницами
    }

    // у элемента и контейнера будет protected свойство Session  в которой есть 
    // доступ к логеру, доступ к тестовым данным, доступ к драйверу
    //
}
