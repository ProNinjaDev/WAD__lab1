using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_product_lab1
{
    public class Person : IPerson
    {
        public int CardNumber { get; set; }
        public string Name { get; set; }
        public DateTime Bithday { get; set; }
        public int calcAge(DateTime date)
        {
            return (int)date.Year - (int)Bithday.Year; 
        }
    }
}
