using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;
using BusinessLogic;

namespace DentistApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
    {
        private int slot = 0;
        private int age = 0;
        private string creditCard = String.Empty;
        Appointment[] appointmentArray = new Appointment[9];
        AppointmentList saveList = new AppointmentList();
        public ObservableCollection<Patient> Applist { get; set; } = null;


        public MainWindow()
        {
            

            InitializeComponent();
            
            //Populating Appointment Combobox
            DateTime theTime = DateTime.Now;
            DateTime initTime = new DateTime(theTime.Year, theTime.Month, theTime.Day, 9, 0, 0);
            for (int i = 0; i < 8; i++)
            {
                appointmentArray[i].Time = initTime.ToString("HH:mm tt");
                initTime = initTime.AddHours(1);
            }
            foreach (Appointment apt in appointmentArray)
            {
                appointmentCombo.Items.Add(apt.Time);
            }
            //Populating Treatment Combobox
            string[] treatments = Enum.GetNames(typeof(TreatmentType));
            foreach (string name in treatments)
            {
                treatmentCombo.Items.Add(name);
            }
            //Populating Payments Combobox
            string[] payments = Enum.GetNames(typeof(PaymentType));
            foreach (string name in payments)
            {
                payCombo.Items.Add(name);
            }
            //Populating Gender Combobox
            string[] gender = Enum.GetNames(typeof(GenderType));
            foreach (string name in gender)
            {
                genderCombo.Items.Add(name);
            }
            //Populating Gender Combobox
            string[] medic = Enum.GetNames(typeof(MedicalConditions));
            foreach (string name in medic)
            {
                medCombo.Items.Add(name);
            }
            creditLabel.Visibility = Visibility.Hidden;
            creditBox.Visibility = Visibility.Hidden;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            AppointmentList appointmentList = new AppointmentList();
            //bool flag = ValidateValues();
            if (slot <= appointmentArray.Length /*&& flag == true*/)
            {
                if (appointmentArray[slot].Patient == null)
                {
                   // appointmentArray[slot].Patient = CreateNewPatient(appointmentArray[slot].Time);
              
                }
            }
          

            //if (appointmentArray[slot].Patient != null)
            //{
            //    Applist.Add(appointmentArray[slot].Patient);
            //}

        }

        private void AppointmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.slot = appointmentCombo.SelectedIndex;
        }

      
    }
}
