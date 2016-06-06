using selenium_wrapper.attribute;
using System;
using System.Diagnostics;
using System.Text;

namespace selenium_wrapper
{
    abstract public class Element : UIElement
    {
        #region fields

        public string _path;
        public string _type;
        #endregion

        public Element(string xpath, string name = "")
        {
            _xpath = xpath;
            _name = name;
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
                        _name  = pa.Name;
                        continue;
                    }
                }
                _path = sb.ToString();
            }
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
