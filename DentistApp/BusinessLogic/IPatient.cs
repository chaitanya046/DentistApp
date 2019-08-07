using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IPatient
    {
        int Age { get; set; }
        string CreditCard { get; set; }
        string ContactNumber { get; set; }
        string Gender { get; set; }
        string CleanTeeth();
    }
}
