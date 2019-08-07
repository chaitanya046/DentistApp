using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DentistApp
{
    class ContactNumberRule:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string contactVal = value.ToString().Trim();
            int contactNum = 0;

            if (!((int.TryParse(value.ToString(), out contactNum)) && (contactVal.Length == 10)))
            {
                return new ValidationResult(false, "Wrong data");
            }


            return ValidationResult.ValidResult;
        }

    }
}
