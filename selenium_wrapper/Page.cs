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
        private string _xpath;
        public Frame(string xpath)
        {
            _xpath = xpath;
        }

        public string XPath
        {
            get
            {
                return XPath;
            }
        }

        public override string ToString()
        {
            return _xpath;
        }
    }

    public abstract class Page
    {
        public class pair
        {
            public Container container { get; set; }
            public int level { get; set; }

            public override string ToString()
            {
                return string.Format("{0} : {1}", container.GetType().Name, level);
            }
        }

        public Page()
        {
            // container
            // frame
            // element

            Stack<pair> els = new Stack<pair>();
            Stack<int> context = new Stack<int>();
            context.Push(0);
            pair current = null;
            pair prev = current;
            List<string> path = new List<string>();
            List<Frame> frames = new List<Frame>();
            int level = 0;
            int down = 0;
            Frame frame = null;

            // Заполнить els элементами страницы
            Type type = this.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i].GetValue(this);
                if (field is Container)
                {
                    var cntr = (Container) field;
                    els.Push(new pair() { container = cntr, level = level});
                }
                else if (field is Element)
                {
                    var element = (Element)field;
                    element.Frames = frames.ToArray();
                }
            }

            while (els.Count > 0)
            {

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

                


                
                current = els.Pop();
                level = current.level;
                prepare_context(frames, context, level);
                prepare_path(path, level);

                var attr = current.container.GetType().GetCustomAttribute(typeof(FrameAttribute));
                if (attr == null) // если контейнер
                {
                    rewrite_path(path, level, current.container.XPath);
                }
                else // если фрейм
                {
                    rewrite_context(frames, context, level, new Frame(current.container.XPath));
                }
                
                down = context.Peek();
                
                type = current.container.GetType();
                fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                bool up_level = false;
                for (int i = 0; i < fields.Length; i++)
                {
                    var field = fields[i].GetValue(current.container);
                    
                    if (field is Container)
                    {
                        var contr = (Container)field;
                        contr.Frames = compile_frames(frames, down, level);
                        contr.XPath = compile_path(path, down, level) + contr.XPath;
                        els.Push(new pair() { container = contr, level = level + 1});
                        up_level = true;
                    }else if (field is Element)
                    {
                        var element = (Element)field;
                        element.Frames = compile_frames(frames, down, level);
                        element.XPath = compile_path(path, down, level) + element.XPath;
                        if (field is CollectionElement)
                        {
                            var collection_element = (CollectionElement)field;
                            collection_element.ItemXPath = compile_path(path, down, level) + collection_element.ItemXPath;
                        }
                    }
                }
                if (up_level)
                {
                    level++;
                }
            }
        }

        private string compile_path(List<string> path, int from, int to)
        {
            while (path.Count() < to + 1)
            {
                path.Add("");
            }

            string result = "";
            for (int i = from; i <= to; i++)
            {
                result += path[i];
            }
            return result;
        }


        private void prepare_path(List<string> path, int position)
        {
            // добавдение недостающих ячеек
            while (path.Count() < position + 1)
            {
                path.Add("");
            }
            // очищение последующих
            for (int i = position + 1; i < path.Count; i++)
            {
                path[i] = "";
            }
        }

        private void prepare_context(List<Frame> frames, Stack<int> context, int position)
        {
            // добавдение недостающих частей
            while (frames.Count() < position + 1)
            {
                frames.Add(null);
            }
            // очищение последующих
            for (int i = position + 1; i < frames.Count; i++)
            {
                frames[i] = null;
            }

            while (context.Peek() > position)
            {
                context.Pop();
            }
        }

        private Frame[] compile_frames(List<Frame> frames, int from, int to)
        {
            List<Frame> result = new List<Frame>();
            for(int i = from; i <= to; i++ )
            {
                if (frames[i] != null)
                {
                    result.Add(frames[i]);
                }
            }

            return result.ToArray();
        }

        private void rewrite_path(List<string> path, int position, string value)
        {
            path[position] = value;
        }

        private void rewrite_context(List<Frame> frames, Stack<int> context, int position, Frame frame)
        {
            frames[position] = frame;
            context.Push(position);
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
