using OpenQA.Selenium;
using selenium_wrapper.attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace selenium_wrapper
{
    public class Frame
    {
        private string _frame;
        public Frame(string xpath)
        {

        }

        public string XPath
        {
            get
            {
                return XPath;
            }
        }
    }

    public abstract class Page
    {
        public class pair
        {
            public Container container { get; set; }
            public int level { get; set; }
        }

        public Page()
        {
            // container
            // frame
            // element

            Stack<pair> els = new Stack<pair>();
            Stack<int> context = new Stack<int>();

            pair current = null;
            pair prev = current;
            List<string> path = new List<string>();
            path.Add("");
            List<Frame> frames = new List<Frame>();
            els.Push(current);
            int level = 0;
            int down = 0;
            Frame frame = null;

            // Заполнить els элементами страницы
            Type type = this.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i].GetValue(current.container);
                if (field is Container)
                {
                    var cntr = (Container) field;
                    els.Push(new pair() { container = cntr, level = level });
                }
                else if (field is Element)
                {
                    var element = (Element)field;
                    element.Frames = frames.ToArray();
                }
            }

            while (els.Count > 0)
            {

                // проверкой предыдущего элемента доводить до нормального состояния
                // дальше выполнять нормальную проверку.

                // если level понизился
                    // если предыдущий элемент фрейм
                        // удалить посследний фрем из списка
                        // удалить последнюю запись  из контекста

                // если level повысился
                    // если текущий элемент фрейм
                        // записать в стек фреймов с путем до предыдущего контекста
                        // записать в контекст позицию
                    // если элемент контейнер
                        // переписать путь по текущему level

                


                frame = null;
                current = els.Pop();
                var attr = current.container.GetType().GetCustomAttributes(typeof(FrameAttribute));
                if (current.level < level)
                {
                    if (attr == null)
                    {
                        rewrite(path, level, current.container.XPath);
                    }
                    else
                    {
                        frames.RemoveAt(frames.Count - 1);
                        context.Pop();
                    }
                }
                else
                {
                    if (attr == null) // если контейнер
                    {
                        rewrite(path, level, current.container.XPath);
                    }
                    else // если фрейм
                    {
                        frames.Add(new Frame(compile_path(path, context.Peek(), level) + current.container.XPath));
                        context.Push(level);
                    }
                }
                
                level = current.level;
                down = context.Peek();
                
                var container = (Container)current.container;
                if (attr != null)
                {
                    down = level;
                    frame = new Frame(container.XPath);
                    frames.Add(frame);
                }
                else
                {
                    rewrite(path, level, container.XPath);
                }
                
                Type type = current.container.GetType();
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                bool up_level = false;
                for (int i = 0; i < fields.Length; i++)
                {
                    var field = fields[i].GetValue(current.container);
                    
                    if (field is Container)
                    {
                        var contr = (Container)field;
                        contr.XPath = compile_path(path, down, level);
                        els.Push(new pair() { container = field, level = level});
                        up_level = true;
                    }else if (field is Element)
                    {
                        var element = (Element)field;
                        element.XPath = compile_path(path, down, level) + element.XPath;
                        element.Frames = frames.ToArray();
                    }
                }
                if (up_level)
                {
                    level++;
                }
                prev = current;
            }
        }

        private string compile_path(List<string> path, int from, int to)
        {
            string result = "";
            for (int i = from; i <= to; i++)
            {
                result += path[i];
            }
            return result;
        }

        private void rewrite(List<string> path, int position, string value)
        {
            while (path.Count() < position + 1)
            {
                path.Add("");
            }
            path[position] = value;
            for (int i = position + 1; i < path.Count; i++)
            {
                path[i] = "";
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
