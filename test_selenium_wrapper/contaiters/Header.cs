using selenium_wrapper;
using selenium_wrapper.attribute;
using selenium_wrapper.element;
using test_selenium_wrapper.contaiters;

namespace test_selenium_wrapper
{
    [Name("заголовок")]
    public class Header : Container
    {
        public Header(string xpath):base(xpath)
        {}

        public Input Login = new Input("логин");
        public Input Password = new Input("пароль");
        public Div div = new Div("div");
    }
}
