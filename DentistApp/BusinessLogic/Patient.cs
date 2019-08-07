using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
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
        None=0,
        Diabetic,
        Hepatitic,
    }
   
    public abstract class Patient : IPatient
    {
        private int age;
        private string contactNumber;
        public string creditCard;
        private string gender;
        private string time;

        public int Age { get => age; set => age = value; }
        public string CreditCard { get => creditCard; set => creditCard =value;}
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Time { get => time; set => time = value; }





        public abstract string CleanTeeth();
        
        public static string ConcealCreditCard(string creditCard)
        {
            string concealedCard = string.Empty;
            char[] charArr = creditCard.ToCharArray();
            for (int i = 4; i < 12; i++)
            {
                charArr[i] = 'X';
                concealedCard = new string(charArr);
            }
            return concealedCard;
        }

    }
}
