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
        // Attributes or properties
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
        public string AppointmentDuration { get; set; }
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
            AppointmentDuration = "30 minutes";
            AppointmentPurpose = "Some description here";
        }

        // Non-default
        public Appointment(string patientName, DateTime patientDoB, string patientAddress, string patientCity, string patientProvince, string patientPostalCode, string patientPhone, string patientEmail, DateTime appointmentTime, string appointmentDuration, string appointmentPurpose)
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
            AppointmentPurpose = appointmentPurpose;
        }

        //====================
        // Methods
        //====================
        // AppointmentToString: Override Instance Method
        // Accepts: Appointment Object
        // Returns: string
        // Description: Override Method that returns an Appointment Object as a string

        // TODO: 
        // This method will be used for printing out the appointment
        // So I think I need to pass an appointment from the list and it will convert the object into the output string
        public override string AppointmentToString(Appointment appointment)
        {
            return $"Patient Name: ${PatientName}\n Age: ${AgeConversion(PatientDoB)}\n Address: {PatientAddress}\n City: {PatientCity}\n Province: {PatientProvince}\n Postal Code: {PatientPostalCode}\n Phone Number: {PatientPhone}\n Email: {PatientEmail}\n\n Appointment Time: {AppointmentTime}\n Appointment Duration: {AppointmentDuration}\n Description: {AppointmentPurpose}";
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




    }

}