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
        private string gender = String.Empty;
        private string medicalCondition = String.Empty;
        private bool ctXray = false;
        private string treatment = String.Empty;
        private string creditCard = String.Empty;
        Appointment[] appointmentArray = new Appointment[9];
        
        AppointmentList saveList = new AppointmentList();
        public ObservableCollection<Patient> Applist { get; set; } = null;
        private ObservableCollection<string> TimeList { get; set; } = null;
        private ObservableCollection<string> GenderList { get; set; } = null;
        private ObservableCollection<string> MedList { get; set; } = null;
        private ObservableCollection<string> TreatmentList { get; set; } = null;
        public MyPatient APatient { get; set; } = new MyPatient();

        public MainWindow()
        {
            

            InitializeComponent();
            Applist = new ObservableCollection<Patient>();
            TimeList = new ObservableCollection<string>();
            GenderList = new ObservableCollection<string>();
            MedList= new ObservableCollection<string>();
            TreatmentList= new ObservableCollection<string>();
            DataContext = this;
            //Populating Appointment Combobox
            DateTime theTime = DateTime.Now;
            DateTime initTime = new DateTime(theTime.Year, theTime.Month, theTime.Day, 9, 0, 0);
            for (int i = 0; i < 9; i++)
            {
                appointmentArray[i] = new Appointment();
                string timeofAppointment = initTime.ToString("HH:mm tt");
                appointmentArray[i].Time = timeofAppointment;
                initTime = initTime.AddHours(1);
                TimeList.Add(timeofAppointment);
            }
            appointmentCombo.ItemsSource = TimeList;
            
            //Populating Treatment Combobox
            string[] treatments = Enum.GetNames(typeof(TreatmentType));
            foreach (string name in treatments)
            {
                TreatmentList.Add(name);
            }
            treatmentCombo.ItemsSource = TreatmentList;

            //Populating Gender Combobox
            string[] gender = Enum.GetNames(typeof(GenderType));
            foreach (string name in gender)
            {
                GenderList.Add(name);
            }
            genderCombo.ItemsSource = GenderList;

            //Populating medical Combobox
            string[] medic = Enum.GetNames(typeof(MedicalConditions));
            foreach (string name in medic)
            {
                MedList.Add(name);
            }
            medCombo.ItemsSource = MedList;
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
                genralError.Foreground = Brushes.Red;
                genralError.Content = "Error Registering Customer";
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

            //gender
            bool genderFlag = true;
            _ = (genderCombo.SelectedIndex == 0) ? gender = "Male" : (genderCombo.SelectedIndex == 1) ? gender = "Female" : gender = "Other";
            if (genderCombo.SelectedIndex == -1)
            {
                genderFlag = false;
            }

            //Medical Conditions
            bool medFlag = true;
            if (medCombo.SelectedIndex == -1)
            {
                medFlag = false;
            }
            else
            {
                medicalCondition = medCombo.SelectedItem.ToString();
            }

            //CT
            bool ctFlag = true;
            _= (radioYes.IsChecked == true) ? ctXray = true : ctXray =  false;
            if(ctXray == false)
            {
                _ = (radioNo.IsChecked == true) ? ctXray = false : ctFlag = false;
            }

            //treatment
            bool treatFlag = true;
            if (treatmentCombo.SelectedIndex == -1)
            {
                treatFlag = false;
            }
            else
            {
                treatment = treatmentCombo.SelectedItem.ToString();
            }

            //creditCard
            bool creditFlag = true;
            string creditCardRaw = creditBox.Text.Trim();
            creditBox.Foreground = Brushes.Black;
            if (creditCardRaw.Length == 16)
            {
                creditCard = ConcealCreditCard(creditCardRaw);
                creditBox.Foreground = Brushes.Black;
            }
            else
            {
                creditBox.Foreground = Brushes.Red;
                creditFlag = false;
            }

            if (!ageFlag)
            {
                ageError.Foreground = Brushes.Red;
                ageError.Content = "Enter a valid Age";
            }
            else if(!genderFlag){
                genderError.Foreground = Brushes.Red;
                genderError.Content = "Enter a valid Gender";
            }
            else if (!medFlag)
            {
                medError.Foreground = Brushes.Red;
                medError.Content = "Enter a valid Medical Condition";
            }
            else if (!ctFlag)
            {
                ctError.Foreground = Brushes.Red;
                ctError.Content = "Enter a valid requirement";
            }
            else if (!treatFlag)
            {
                treatmentError.Foreground = Brushes.Red;
                treatmentError.Content = "Enter a valid Treatment";
            }
            else if (!creditFlag)
            {
                creditError.Foreground = Brushes.Red;
                creditError.Content = "Enter a valid Credit Card";
            }
            return ageFlag && genderFlag && medFlag && ctFlag && treatFlag && creditFlag;
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
                    patient = new ChildPatient() { Age = age, Gender = gender, MedicalCondition = medicalCondition, CtXray = ctXray, Treatment = treatment, CreditCard = creditCard };
                }
                else { patient = new AdultPatient() { Age = age, Gender = gender, MedicalCondition = medicalCondition, CtXray = ctXray, Treatment = treatment, CreditCard = creditCard }; }

            
           
            //clearing form
            ageBox.Text = "";
            genderCombo.SelectedIndex = -1;
            medCombo.SelectedIndex = -1;
            treatmentCombo.SelectedIndex = -1;
            creditBox.Text = "";
            radioNo.IsChecked = false;
            radioYes.IsChecked = false;
            appointmentError.Content = "";
            ageError.Content = "";
            medError.Content = "";
            treatmentError.Content = "";
            creditError.Content = "";
            appointmentError.Content = "";
            genderError.Content = "";
            genralError.Content = "";
            ctError.Content = "";
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
                newPatient.Gender = patient.Gender;
                newPatient.MedicalCondition = patient.MedicalCondition;
                newPatient.CtXray = patient.CtXray;
                newPatient.Treatment = patient.Treatment;
                newPatient.CreditCard = patient.CreditCard;
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
            TimeList.RemoveAt(slot);
            MessageBox.Show("Save Successful");
            
        }

        private string ConcealCreditCard(string creditCard)
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

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var query = from Appointment in Applist
                        where Appointment.Age == int.Parse(txtSearch.Text)
                        select Appointment;
            MyGrid.ItemsSource = query;
        }

    }
}
