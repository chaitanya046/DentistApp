using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{
    [XmlRoot("AppointmentList")]    
    public class AppointmentList : IEnumerable<Appointment>, IDisposable
    {
        [XmlArray("Appointments")]

        [XmlArrayItem("Appointment", typeof(Appointment))]
        private List<Appointment> appointments = null;

        public List<Appointment> Appointments { get => appointments; set => appointments = value; }

        public AppointmentList()
        {
            appointments = new List<Appointment>();
        }

        public void Add(Appointment apt) {
            appointments.Add(apt);
        }
        public void Remove(Appointment a)
        {
            appointments.Remove(a);
        }

        public int Count()
        {
            return appointments.Count();
        }
        public void Clear()
        {
            appointments.Clear();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Sort()
        {
            appointments.Sort();
        }
        public IEnumerator<Appointment> GetEnumerator()
        {
            return ((IEnumerable<Appointment>)appointments).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Appointment>)appointments).GetEnumerator();
        }
        public Appointment this[int i]
        {
            get { return appointments[i]; }
            set { appointments[i] = value; }
        }
    }
}
