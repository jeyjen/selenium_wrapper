using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper.element
{
    public class Button : Element
    {
        public Button(string xpath, string name = "") : base(xpath, name)
        {
        }

        public override void Click()
        {
            base.Click();
        }
    }
}
