using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DentistApp
{
    class CreditRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string numVal = String.Empty;
            if ((value.ToString().Trim().Length) != 16)
            {
                return new ValidationResult(false, "Invalid Credit Card number");
            }

            return ValidationResult.ValidResult;
        }

    }
}
