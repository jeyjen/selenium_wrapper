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
            public object obj { get; set; }
            public int level { get; set; }
        }

        public Page()
        {
            // container
            // frame
            // element

            Stack<pair> els = new Stack<pair>();

            pair current = new pair() { obj = this, level = -1 };
            pair prev = current;
            List<string> path = new List<string>();
            List<Frame> frames = new List<Frame>();
            els.Push(current);
            int level = 0;
            int down = 0;
            do
            {
                current = els.Pop();
                if (current.level < level)
                {
                    // если предыдущий был фрейм то удалить последний фрейм
                    level = current.level;
                    if (prev.obj is Container)
                    {
                        //path;
                    }
                }
                var attr = current.obj.GetType().GetCustomAttributes(typeof(FrameAttribute));
                var container = (Container)current.obj;
                Frame frame = null;
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
                
                Type type = current.obj.GetType();
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                bool up_level = false;
                for (int i = 0; i < fields.Length; i++)
                {
                    var field = fields[i].GetValue(current.obj);
                    
                    if (field is Container)
                    {
                        els.Push(new pair() { obj = field, level = level});
                        up_level = true;
                    }else if (field is Element)
                    {
                        var element = (Element)field;
                        //element.XPath = compile_path(path, element.XPath);
                        //element.Frames = frames.ToArray();
                    }
                }
                if (up_level)
                {
                    level++;
                }
                prev = current;
            }
            while (els.Count > 0);
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
