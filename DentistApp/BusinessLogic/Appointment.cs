using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Appointment:IComparable<Appointment>
    {
        private string time;
        private Patient patient;

        public string Time { get => time; set => time = value; }
        public Patient Patient { get => patient; set => patient = value; }

        public int CompareTo(Appointment other)
        {
            return this.patient.Age.CompareTo(other.patient.Age);
        }
    }
}
