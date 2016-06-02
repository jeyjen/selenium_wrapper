using OpenQA.Selenium;
using selenium_wrapper.attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace selenium_wrapper
{
    public abstract class Page
    {
        public class pair
        {
            public object obj { get; set; }
            public int level { get; set; }
        }

        public Page()
        {
            // container
            // frame
            // element

            Stack<pair> els = new Stack<pair>();

            pair current;
            string full_xpath = "";
            List<Frame> frames = new List<Frame>();
            els.Push(new pair() { obj = this, level = 0 });
            int level = 1;
            do
            {
                current = els.Pop();
                if (current.level < level)
                {
                    // xpath пути и набора фреймов
                }
                
                Type myType = current.GetType();
                FieldInfo[] fields = myType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < fields.Length; i++)
                {
                    var field = fields[i].GetValue(current);
                    
                    var attr = field.GetType().GetCustomAttribute(typeof(ContainerAttribute));
                    if (attr != null)
                    {
                        els.Push(new pair() { obj = field, level = level });
                        level++;
                        continue;
                    }
                    attr = field.GetType().GetCustomAttribute(typeof(FrameAttribute));
                    if (attr != null)
                    {
                        els.Push(new pair() { obj = field, level = level });
                        level++;
                        continue;
                    }

                    attr = field.GetType().GetCustomAttribute(typeof(ElementAttribute));
                    if (attr != null)
                    {
                        //els.Push(new pair() { obj = field, level = level });
                        level++;
                        continue;
                    }

                    // если объект является фреймом
                    // добавить набор фреймов для включенных элементов
                    // если объект блок
                    // то выполняется добавление xpath блока к фрейму
                    // если это элемент
                    // записать подготовленные фреймы для переключения
                    // сформировать результирующий xpath

                }
            }
            while (els.Count > 0);

            

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
