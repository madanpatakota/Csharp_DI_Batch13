using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_DI_Batch13
{
    class Class1
    {
        private int _id;
        private string _name;
        public Class1(int k , string j)
        {
            _id = k;
            _name = j;
        }

        public void printMessage()
        {
            Console.WriteLine($"{_id} , {_name}");
        }
        public int getnumber()
        {
            return 10;
        }

        public int getnumber2()
        {
            return 20;
        }
    }


    class Class2
    {
        static void Main()
        {
            Class1 c1 = new Class1(0,"");
            c1.getnumber();
        }
    }


    class Class3
    {
        static void Main()
        {
            Class1 c1 = new Class1(0, "");
            c1.getnumber2();
        }
    }


}
