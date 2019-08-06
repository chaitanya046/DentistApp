using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistApp
{
    public enum TreatmentType
    {
        Filling=0, Extraction, RootCanalTreatment, Bleaching, Polishing, OrthodonticTreatment, Dentures, Implant
    }
    public enum GenderType
    {
        Male = 0,
        Female,
        Other 
    }
    public enum PaymentType
    {
        Insurance = 0,
        OHIP,
        Other
    }
    public enum MedicalConditions
    {
        Diabetic = 0,
        Hepatitic,
    }
    public delegate void DelegateForPatient();
    public class Patient : IPatient
    {
        private int age;
        private string contactNumber;
        public string creditCard;
        private DelegateForPatient patientDelegate;
        private string gender;

        public int Age { get => age; set => age = value; }
        public string CreditCard { get => creditCard; set => creditCard =value;}
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Gender { get => gender; set => gender = value; }

        public string ViewCreditCard { get => ConcealedCard(); }

        private string ConcealedCard()
        {
            creditCard = creditCard.Insert(4, " ");
            string creditCardOneSpace = creditCard.Insert(9, " ");
            string creditCardTwoSpace = creditCardOneSpace.Insert(14, " ");
            char[] passArray = creditCardTwoSpace.ToCharArray();
            for (int i = 5; i < 9; i++)
            {
                passArray[i] = 'X';
            }
            for (int i = 10; i < 14; i++)
            {
                passArray[i] = 'X';
            }
            return new string(passArray);
        }



    }
}
