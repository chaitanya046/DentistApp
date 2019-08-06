using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DentistApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            String[] appointmentArray = new String[9];
            InitializeComponent();
            //Populating Appointment Combobox
            DateTime theTime = DateTime.Now;
            DateTime initTime = new DateTime(theTime.Year, theTime.Month, theTime.Day, 9, 0, 0);
            for (int i = 0; i < 8; i++)
            {
                appointmentArray[i] = initTime.ToString("HH:mm tt");
                initTime = initTime.AddHours(1);
            }
            foreach (String apt in appointmentArray)
            {
                appointmentCombo.Items.Add(apt);
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
    }
}
