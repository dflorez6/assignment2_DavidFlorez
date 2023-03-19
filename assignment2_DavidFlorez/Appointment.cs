using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_DavidFlorez
{
    // Class
    public class Appointment : Office
    {
        //====================
        // Properties
        //====================                
        public string PatientName { get; set; }
        public DateTime PatientDoB { get; set; }
        public string Patient { get; set; }
        public string PatientAddress { get; set; }
        public string PatientCity { get; set; }
        public string PatientProvince { get; set; }
        public string PatientPostalCode { get; set; }
        public string PatientPhone { get; set; }
        public string PatientEmail { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string AppointmentDuration { get; set; }
        public int AppointmentDurationIndex { get; set; }
        public string AppointmentPurpose { get; set; }

        //====================
        // Constructors
        //====================
        // Default
        public Appointment()
        {
            // Patient's data
            PatientName = "FirstName LastName";
            PatientDoB = Convert.ToDateTime("March 1, 2005");
            PatientAddress = "108 University Ave";
            PatientCity = "Waterloo";
            PatientProvince = "ON";
            PatientPostalCode = "N1C 2B6";
            PatientPhone = "1234567890";
            PatientEmail = "user@email.com";

            // Appointment's Data
            AppointmentTime = DateTime.Now;
            AppointmentDuration = "15 minutes";
            AppointmentDurationIndex = 0;
            AppointmentPurpose = "Some description here";
        }

        // Non-default
        public Appointment(string patientName, DateTime patientDoB, string patientAddress, string patientCity, string patientProvince, string patientPostalCode, string patientPhone, string patientEmail, DateTime appointmentTime, string appointmentDuration, int appointmentDurationIndex, string appointmentPurpose)
        {
            // Patient's data
            PatientName = patientName;
            PatientDoB = patientDoB;
            PatientAddress = patientAddress;
            PatientCity = patientCity;
            PatientProvince = patientProvince;
            PatientPostalCode = patientPostalCode;
            PatientPhone = patientPhone;
            PatientEmail = patientEmail;

            // Appointment's Data
            AppointmentTime = appointmentTime;
            AppointmentDuration = appointmentDuration;
            AppointmentDurationIndex = appointmentDurationIndex;
            AppointmentPurpose = appointmentPurpose;

            // Calculates Appointment Time End Based on Appointment Time & Duration Params
            AppointmentEndTime = CalculateAppointmentEndTime(appointmentTime, appointmentDurationIndex);
        }

        //====================
        // Methods
        //====================
        // AppointmentToString: Override Instance Method
        // Accepts: Appointment Object
        // Returns: string
        // Description: Override Method that returns an Appointment Object as a string
        // * This method will be used for printing out the booked appointments
        public override string AppointmentToString(Appointment appointment)
        {
            // Building the return string with the expected output style
            string returnString;
            returnString = "-----------------------------------------------------\n";
            returnString += $"Patient Name: {PatientName}\n";
            returnString += $"Age: ${AgeConversion(PatientDoB)}\n";
            returnString += $"Address: {PatientAddress}\n";
            returnString += $"City: {PatientCity}\n";
            returnString += $"Province: {PatientProvince}\n";
            returnString += $"Postal Code: {PatientPostalCode}\n";
            returnString += $"Phone Number: {PatientPhone}\n";
            returnString += $"Email: {PatientEmail}\n";
            returnString += $"\n";
            returnString += $"Appointment Time: {AppointmentTime.ToString("MM/dd/yyyy")} {AppointmentTime.ToString("hh:mmtt").ToLower()}\n";
            returnString += $"Appointment Duration: {AppointmentDuration}\n";
            returnString += $"Description: {AppointmentPurpose}\n";

            return returnString;
        }


        //====================
        // Helper Methods
        //====================
        // AgeConversion: Instance Method
        // Accepts: DateTime
        // Returns: int
        // Description: Calculates patient's age based on patient's date of birth 
        public int AgeConversion(DateTime patientDoB)
        {
            // Initial Declarations
            const double DAYS_IN_A_YEAR = 365.242199; // This constant is the actual number of days within a year

            // Calculate current age
            double currentAge = ((DateTime.Now - patientDoB).TotalDays) / DAYS_IN_A_YEAR;
            return Convert.ToInt32(currentAge);
        }

        // AgeConversion: Instance Method
        // Accepts: DateTime & int
        // Returns: DateTime
        // Description: Calculates appointment time end based on appointment time & duration params
        public DateTime CalculateAppointmentEndTime(DateTime appointmentTime, int appointmentDurationIndex)
        {
            // Initial Declarations
            string appointmentDuration = "";

            // Depending on the passed parameter that correlates to an index in de comboBox for selecting time duration,
            // the switch is beign used to return only a string that represents minutes for easier calculations
            switch (appointmentDurationIndex)
            {
                case 0:
                    appointmentDuration = "15";
                    break;
                case 1:
                    appointmentDuration = "30";
                    break;
                case 2:
                    appointmentDuration = "45";
                    break;
                case 3:
                    appointmentDuration = "60";
                    break;
            }

            // Depending on the duration selected by the user from the combo box, the duration will be converted into TimeSpan
            // and will be used to calculate the appointment's end time
            TimeSpan durationInMinutes = TimeSpan.FromMinutes(int.Parse(appointmentDuration));
            DateTime appointmentEndTime = AppointmentTime + durationInMinutes;

            return appointmentEndTime;
        }

    }

}