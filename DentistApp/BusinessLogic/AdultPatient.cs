using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
namespace DentistApp
{
    public class AdultPatient : Patient
    {
        
        public override string CleanTeeth()
        {
            return "Clean adult teeth";
        }

    }
}
