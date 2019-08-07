using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class AppointmentList : IEnumerable<Appointment>
    {
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

        public IEnumerator<Appointment> GetEnumerator()
        {
            return ((IEnumerable<Appointment>)appointments).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Appointment>)appointments).GetEnumerator();
        }
    }
}
