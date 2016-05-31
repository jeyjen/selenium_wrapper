using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public class Driver
    {
        private static Driver _instance;

        private Driver()
        {
        }

        public static Driver Instance()
        {
            if (_instance == null)
            {
                _instance = new Driver();
            }
            return _instance;
        }

        public T Navigate<T>(string url) where T :Page, new()
        {
            return new T();
        }

        public T Switch<T>() where T : Page, new()
        {
            return null;
        }
    }
}
