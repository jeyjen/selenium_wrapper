using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_Copy_Dictionary
{
    [Element("Поле ввода")]
    public class Input: Element
    {
        public Input(string name) : base(name)
        { }
        public string Text { get; set; }     
    }
}
