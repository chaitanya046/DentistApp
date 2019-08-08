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
        public MyPatient APatient { get; set; } = new MyPatient();

        public MainWindow()
        {
            

            InitializeComponent();
            Applist = new ObservableCollection<Patient>();
            DataContext = this;
            //Populating Appointment Combobox
            DateTime theTime = DateTime.Now;
            DateTime initTime = new DateTime(theTime.Year, theTime.Month, theTime.Day, 9, 0, 0);
            for (int i = 0; i < 9; i++)
            {
                appointmentArray[i] = new Appointment();
                appointmentArray[i].Time = initTime.ToString("HH:mm tt");
                appointmentCombo.Items.Add(initTime.ToString("HH:mm tt"));
                initTime = initTime.AddHours(1);
            }
            //foreach (Appointment apt in appointmentArray)
            //{
            //    appointmentCombo.Items.Add(apt.Time);
            //}
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
           
            bool flag = ValidateValues();
            if (slot <= appointmentArray.Length && flag == true)
            {
                if (appointmentArray[slot].Patient == null)
                {
                    
                    appointmentArray[slot].Patient = CreateNewPatient();
                    appointmentArray[slot].Patient.Time = appointmentCombo.SelectedValue.ToString();
                    appointmentArray[slot].Time = appointmentCombo.SelectedValue.ToString();
                    saveList.Add(appointmentArray[slot]);
                }
            }
            else
            {
                MessageBox.Show("Wrong Input OR Slot Already taken");
            }


            if (appointmentArray[slot].Patient != null)
            {
                Applist.Add(appointmentArray[slot].Patient);
            }
            MyGrid.ItemsSource = Applist; 

        }

        private bool ValidateValues()
        {
            //Age
            bool ageFlag = true;
            string ageString = string.Empty;
            ageString = ageBox.Text;
            if ((int.TryParse(ageString, out age) && age >= 2 && age <= 99))
            {
                ageBox.Foreground = Brushes.Black;
                ageBox.Text = age.ToString();
                ageFlag = true;
            }
            else
            {
                ageBox.Foreground = Brushes.Red;
                ageFlag = false;
            }
            return ageFlag;
        }

        private void AppointmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.slot = appointmentCombo.SelectedIndex;
        }

        private Patient CreateNewPatient()
        {
          Patient patient  = null;
            // determining patient type
             
                if (age <= 15)
                {
                    patient = new ChildPatient() { Age = age };
                }
                else { patient = new AdultPatient() {Age=age }; }

            
           
            ageBox.Text = "";
            //creditBox.Text = "";
            
            return patient;
        }

        private void BtnDisplay_Click(object sender, RoutedEventArgs e)
        {
            saveList.Clear();
            ReadFromXML();
            Applist.Clear();
            for (int i = 0; i < saveList.Count(); i++)
            {
                Patient patient = saveList[i].Patient;
                MyPatient newPatient = new MyPatient();
                newPatient.Age = patient.Age;
                newPatient.Time = patient.Time;
                //newPatient.Gender
                //string[] arrStr = patient.GetType().ToString().Split('.');
                //string fullType = arrStr[arrStr.Length - 1];
                //newPatient.Type = fullType.Substring(0, fullType.Length - 4);
                Applist.Add(newPatient);
            }
            MyGrid.ItemsSource = Applist;
        }
        private void WriteToXML(AppointmentList myList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList));
            TextWriter writer = new StreamWriter("appointments.xml");
            serializer.Serialize(writer, myList);
            writer.Close();
        }
        private void ReadFromXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList));
            TextReader tr = new StreamReader("appointments.xml");
            saveList = (AppointmentList)serializer.Deserialize(tr);
            tr.Close();


        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //saveList.Clear();
            //foreach (Appointment apt in appointmentList)
            //{
            //    saveList.Add(patient);
            //}
            WriteToXML(saveList);
            MessageBox.Show("Save Successful");
            
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var query = from Appointment in Applist
                        where Appointment.Age == int.Parse(txtSearch.Text)
                        select Appointment;
            MyGrid.ItemsSource = query;
        }
    }
}
