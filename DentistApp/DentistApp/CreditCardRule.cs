using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DentistApp
{
    class CreditCardRule:ValidationRule
    {
 
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string creditVal = value.ToString().Trim();
            int creditNum = 0;

            if (!((int.TryParse(value.ToString(), out creditNum))&&(creditVal.Length==16)))
            {
                return new ValidationResult(false, "Wrong data");
            }


            return ValidationResult.ValidResult;
        }

      
    }
}
