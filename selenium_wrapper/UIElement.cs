using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public abstract class UIElement
    {
        #region fields
        internal Page _page;
        internal Session _session;
        internal Container _parent;
        internal string _xpath;
        internal Frame[] _frames;
        internal IWebElement _selenium_element;
        protected string _name;
        #endregion
        #region properties
        protected Page Page
        {
            get { return _page; }
        }
        protected Session Session
        {
            get { return _session; }
        }
        protected Container Parent
        {
            get { return _parent; }
        }
        protected IWebElement SeleniumElement
        {
            get
            {
                if (_selenium_element == null)
                {
                    _selenium_element = _session.Driver.FindElement(_xpath);
                }
                return _selenium_element;
            }
        }
        public string XPath
        {
            get { return _xpath; }
        }
        internal Frame[] Frames
        {
            get { return _frames; }
        }
        #endregion

        public virtual void Click()
        {
            // реализовать нажатие на элемент
            SeleniumElement.Click();
        }
        
        public virtual void SetText(string text)
        {
            SeleniumElement.SendKeys(text);
        }

        public bool Displayed
        {
            get
            {
                return _selenium_element.Displayed;
            }
        } 

        public bool Enabled
        {
            get
            {
                return _selenium_element.Enabled;
            }
        }

    }
}
