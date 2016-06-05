using selenium_wrapper.attribute;
using System;
using System.Diagnostics;
using System.Text;

namespace selenium_wrapper
{
    abstract public class Element
    {
        public Frame[] Frames { get; set; }
        public string XPath { get; set; }


        public string _page;
        public string _path;
        public string _type;

        public Element(string xpath)
        {
            XPath = xpath;

            // Получение базовой страницы
            StackFrame[] frames = new StackTrace().GetFrames();
            StringBuilder sb = new StringBuilder();
            foreach (var it in frames)
            {
                var attrs = it.GetMethod().ReflectedType.GetCustomAttributes(false);
                foreach (var item in attrs)
                {
                    var pa = item as NameAttribute;
                    if (pa != null)
                    {
                        _page = pa.Name;
                        continue;
                    }
                   /////////////
                    //if (ea != null)
                    //{
                    //    sb.Insert(0,string.Format(" > {0}", ea.Name));
                    //}
                }
                _path = sb.ToString();
            }

        }
        [Action("нажатие")]
        public void Click()
        {
            Debug.WriteLine(GetActionLog());
        }

        protected string GetActionLog()
        {
            StackFrame frame = new StackTrace().GetFrames()[1];
            var attrs = frame.GetMethod().GetCustomAttributes(false);
            string action = "";
            ActionAttribute act;
            foreach (var item in attrs)
            {
                act = item as ActionAttribute;
                if (act != null)
                {
                    action = act.Name;
                    break;
                }
            }
            return string.Format("<act>{0}</act> на <el>\"{1}\"</el> (\"<page>{2}</page> <path>{3}</path>\")", action, "имя элемента", _page, _path);
        }
    }
    
}
