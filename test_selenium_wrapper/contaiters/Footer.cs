﻿using selenium_wrapper;
using selenium_wrapper.element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selenium_wrapper.contaiters
{
    public class Footer : Container
    {
        public Input email = new Input("");
        public Div div = new Div("div");
        public Footer(string xpath):base(xpath)
        { }
    }
}