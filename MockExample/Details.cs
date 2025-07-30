using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExample
{
    public class Details:IDetails
    {
       public string ShowCompany()
        {
            return "It's from Wipro Chennai..";
        }
        public string ShowStudent()
        {
            return "Hi I am pravali..";
        }
    }
}
