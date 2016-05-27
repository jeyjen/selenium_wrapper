using System;

namespace RP_Copy_Dictionary
{
    public abstract class Page
    {
        public abstract bool IsCurrentPage();

        /// <summary>
        /// проверяет наличие обязательных полей на странице
        /// </summary>
        public void CheckRequireElements()
        { }
    }

    [Page("Главная страница")]
    public class MainPage
    {
        public Block Block = new Block("Блок данных о пользователе");
    }

    [Page("Главная страница")]
    public class LoginPage
    {
        public Input Login = new Input("Логин");
        public Input Password = new Input("Пароль");
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class PageAttribute : Attribute
    {
        private string _name;
        public PageAttribute(string name)
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
