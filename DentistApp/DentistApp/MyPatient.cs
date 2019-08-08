using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
namespace DentistApp
{
    public class MyPatient:Patient
    {
       
            string type;
            Patient innerPatient;

            public string Type { get => type; set => type = value; }
            public Patient InnerPatient { get => innerPatient; set => innerPatient = value; }

        public override string CleanTeeth()
        {
            throw new NotImplementedException();
        }
    }
  }

