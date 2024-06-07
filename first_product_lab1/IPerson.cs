using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_product_lab1
{
    public interface IPerson 
    {
        int CardNumber { get; set; }
        string Name { get; set; }
        DateTime Bithday { get; set; }
        int calcAge (DateTime date);
        //Person GetPerson { get; set; }
        
    }
}
