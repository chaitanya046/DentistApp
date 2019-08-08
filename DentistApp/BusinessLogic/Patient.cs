using DentistApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
    public enum MedicalConditions
    {
        None=0,
        Diabetic,
        Hepatitic,
    }
    [XmlInclude(typeof(ChildPatient))]
    [XmlInclude(typeof(AdultPatient))]
    
    public abstract class Patient : IPatient
    {
        private int age;
        private string contactNumber;
        public string creditCard;
        private string gender;
        private string time;
        private string medicalCondition;
        private bool ctXray;
        private string treatment;

        public int Age { get => age; set => age = value; }
        public string CreditCard { get => creditCard; set => creditCard =value;}
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Time { get => time; set => time = value; }
        public string MedicalCondition { get => medicalCondition; set => medicalCondition = value; }
        public bool CtXray { get => ctXray; set => ctXray = value; }
        public string Treatment { get => treatment; set => treatment = value; }

        public abstract string CleanTeeth();
    }
}
