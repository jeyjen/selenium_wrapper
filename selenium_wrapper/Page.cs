using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Reflection;

namespace selenium_wrapper
{
    public abstract class Page
    {
        public Page()
        {
            // container
            // frame
            // element

            Type myType = this.GetType();
            FieldInfo[] myFields = myType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            for(int i = 0; i < myFields.Length; i++)
            {
                Debug.WriteLine(myFields[i].Name);
                Debug.WriteLine(myFields[i].GetValue(this));

                // если объект является фреймом
                    // добавить набор фреймов для включенных элементов
                // если объект блок
                    // то выполняется добавление xpath блока к фрейму
                // если это элемент
                    // записать подготовленные фреймы для переключения
                    // сформировать результирующий xpath

            }

        }
        /// <summary>
        /// Проверяет что текущая страница является той страницей которая отображается
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public abstract bool IsPage(Driver driver);

        // проверяет наличие всех элементов

        // Реализовать выделение элементов на скриншоте с подписью ошибки
        // Выполнить сохранение прежних позиций элементов управления и их размеров
            // Элемент управления содержит неверную надпись
            // Элемент управления не доступен для редактирования
            // Элемент управления не виден
                // тогда подсвечивать контейнер в котором он находится.
        
    }
}
