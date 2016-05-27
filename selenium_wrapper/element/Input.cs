using selenium_wrapper.attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper.element
{
    [Element("поле ввода")]
    public class Input: Element
    {
        public Input(string name) : base(name)
        { }

        [Action("установка значения")]
        public void SetText()
        {
            Debug.WriteLine(GetActionLog());
        }
    }
}
