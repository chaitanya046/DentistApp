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
    class Patient : IPatient
    {
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CreditCard { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
