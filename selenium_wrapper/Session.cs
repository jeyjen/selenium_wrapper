using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public class Session
    {
        public object TestData { get; set; }

        public object Log { get; }

        public Driver Driver {get;set;}

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
