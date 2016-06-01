using selenium_wrapper;
using selenium_wrapper.element;

namespace test_selenium_wrapper
{
    [Element("заголовок")]
    public class Header : Element
    {
        public Header(string name):base(name)
        {}

        public Input Login = new Input("логин");
        /// <summary>
        /// Пароль для ввода
        /// </summary>
        public Input Password = new Input("пароль");
        public override string ToString()
        {
            return "Заголовок";
        }
    }
}
