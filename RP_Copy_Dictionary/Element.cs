using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_Copy_Dictionary
{
    abstract public class Element
    {
        public string _page;
        public string _name;
        public bool _is_requere;

        public Element(string name, bool is_require = false)
        {
            _name = name;
            _is_requere = is_require;
            StackTrace st = new StackTrace();
            StackFrame[] frames = st.GetFrames();
            foreach (var it in frames)
            {
                var attrs = it.GetMethod().ReflectedType.GetCustomAttributes(false);
                foreach (var item in attrs)
                {
                    var pa = item as PageAttribute;
                    if (pa != null)
                    {
                        _page = pa.Name;
                    }
                }
            }

        }
        // Выполняемый метод
        public void Click()
        {
            Console.WriteLine(string.Format("Выполнено нажатие на \"{0}\" на \"{1}\"", _name, _page));
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ElementAttribute : Attribute
    {
        private string _name;
        public ElementAttribute(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
