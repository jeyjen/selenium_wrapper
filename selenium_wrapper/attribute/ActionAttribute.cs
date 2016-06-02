using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper.attribute
{
    [AttributeUsage(AttributeTargets.Method)]

    [Serializable]
    class ActionAttribute : MethodInterceptionAspect
    {
        private string _name;
        public ActionAttribute(string name)
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

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var obj = args.Instance;
            Debug.WriteLine("вызван метод!!!");
            args.Proceed();

            // Выполнить логирование выполнения метода

        }
    }

    /*
     class ActionAttribute : Attribute
    {
        private string _name;
        public ActionAttribute(string name)
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
     */
}
