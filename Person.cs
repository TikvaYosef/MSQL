using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQL
{
    internal class Person
    {
        public string fname;
        public string lname;
        public int age;
        public string birthday;

        public Person(string fname, string lname, int age, string birthday)
        {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
            this.birthday = birthday;
        }

        public void printToConsole()
        {
            Console.WriteLine($"{this.fname} {this.lname} {this.age} {this.birthday}");
        }
    }
}
