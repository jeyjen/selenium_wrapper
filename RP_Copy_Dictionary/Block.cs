using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_Copy_Dictionary
{
    public class Block : Element
    {
        public Block(string name):base(name)
        { }
        public Input LastName = new Input("Фамилия");
        public Input FirstName = new Input("Имя");
    }
}
