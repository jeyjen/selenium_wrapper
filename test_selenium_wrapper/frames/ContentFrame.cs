using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_selenium_wrapper.contaiters;

namespace test_selenium_wrapper.frames
{
    public class ContentFrame: Frame
    {
        public Input table = new Input("");
        public Sidebar sidebar = new Sidebar("sidebar");
        public ContentFrame(string xpath) : base(xpath)
        { }
    }
}
