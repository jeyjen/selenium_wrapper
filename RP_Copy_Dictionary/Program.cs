using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_Copy_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MainPage MainPage = new MainPage();
            MainPage.Block.FirstName.Click();
            MainPage.Block.LastName.Click();
            MainPage.Block.Click();

            LoginPage lb = new LoginPage();
            lb.Login.Click();
            Console.ReadLine();

            /*
            Dictionary<string, Container> c1 = new Dictionary<string, Container>();
            c1.Add("v1", new Container() { p1 = 1, p2 = "p2_1"});
            c1.Add("v2", new Container() { p1 = 2, p2 = "p2_2" });

            var c2 = new Dictionary<string, Container>(c1);  
            
            Container c = c2["v1"];
            c.p2 = "22222222222";
            c2["v1"] = c;

            foreach (var it in c1)
            {
                Console.WriteLine("{0} {1}", it.Key, it.Value);
            }

            Console.WriteLine("новый");

            foreach (var it in c2)
            {
                Console.WriteLine("{0} {1}", it.Key, it.Value);
            }
            */
            Console.ReadLine();
        }
    }
}
