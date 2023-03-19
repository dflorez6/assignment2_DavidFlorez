using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Net.Mail;

namespace assignment2_DavidFlorez
{
    public partial class Form1 : Form
    {
        //====================
        // Object Declarations
        //====================
        Office office;
        Appointment appointment;

        //====================
        // Form
        //====================
        public Form1()
        {
            InitializeComponent();

            // Creating instances on Form // TODO: * IMPORTANT STEP TO CREATE INSTANCES OF THE CLASSES
            office = new Office();
            appointment = new Appointment();
        }

        //====================
        // Book Appointment
        //====================
        // TODO: Add Description
        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            // Office office = OfficeInstance();

            // TODO: Assignment Requirements
            /*
             * Book appointment button shows correct message popups based on if there are errors present or not, as well as a 
             * success popup outlining the appointment time
            */

            // Capturing User Input: Patient's Data
            string patientName = txtPatientName.Text;
            DateTime patientDateOfBirth = Convert.ToDateTime(dtpPatientDoB.Text); // Convert Input Data (string) to DateTime
            string patientAddress = txtPatientAddress.Text;
            string patientCity = txtPatientCity.Text;
            string patientProvince = txtPatientProvince.Text;
            string patientPostalCode = txtPatientPostalCode.Text;
            string patientPhone = txtPatientPhone.Text;
            string patientEmail = txtPatientEmail.Text;

            // Capturing User Input: Appointment's Data
            DateTime appointmentTime = Convert.ToDateTime(dtpAppointmentTime.Text); // Convert Input Data (string) to DateTime
            string appointmentDuration = cboAppointmentDuration.Text;
            int appointmentDurationIndex = cboAppointmentDuration.SelectedIndex;
            string appointmentPurpose = txtAppointmentPurpose.Text;

            //--------------------
            // Validations
            //--------------------
            // Boolean declarations for returned helper methods returned values
            bool validatedPatientName = ValidationHelper.IsValidString(patientName); // TODO: out parameter
            bool validatedPatientAge = ValidationHelper.IsValidPatientAge(patientDateOfBirth);
            bool validatedPatientAddress = ValidationHelper.IsValidString(patientAddress);
            bool validatedPatientCity = ValidationHelper.IsValidString(patientCity);
            bool validatedPatientProvince = ValidationHelper.IsValidString(patientProvince);
            bool validatedPatientPostalCode = ValidationHelper.IsValidPostalCode(patientPostalCode);
            bool validatedPatientPhone = ValidationHelper.IsValidPhoneNumber(patientPhone);
            bool validatedPatientEmail = ValidationHelper.IsValidEmail(patientEmail);
            bool validatedAppointmentDuration = ValidationHelper.IsValidString(appointmentDuration);
            bool validatedAppointmentPurpose = ValidationHelper.IsValidString(appointmentPurpose);

            // TODO: VALIDATE AppointmentTime to make sure it doesn't overlap with an already booked appointment
            bool validatedAppointmentTime; // Will have another validation that will check that it doesn't overlap with an already booked appointment

            // If all input fields have been validated create Appointment
            // A bit nasty but it's an extra validation layer to make sure that all the required information is passed to book an appointment
            if (validatedPatientName && validatedPatientAge && validatedPatientAddress && validatedPatientCity && validatedPatientProvince && validatedPatientPostalCode && validatedPatientPhone && validatedPatientEmail && validatedAppointmentDuration && validatedAppointmentPurpose)
            {
                // Instantiating Appointment Object (non-default constructor)
                Appointment appointment = new Appointment(
                    patientName, patientDateOfBirth, patientAddress, patientCity, patientProvince, patientPostalCode, patientPhone, patientEmail,
                    appointmentTime, appointmentDuration, appointmentDurationIndex, appointmentPurpose
                    );

                // Booking an appointment
                office.BookAppointment(appointment);

                // TODO: NOT YET UNCOMMENT LATER
                /*
                */
                Console.WriteLine("Office Object inside validation-----------");
                Console.WriteLine(office.NumberOfAppointments());


                // TODO: NOT YET UNCOMMENT LATER
                /*
                Console.WriteLine("Office Object appointment list VALIDATED-----------");
                foreach (var item in Office.ShowAppointments())
                {
                    Console.WriteLine(item);
                }
                */


            }

        }

        //====================
        // Reset Fields
        //====================
        // TODO: Add Description
        private void btnResetFields_Click(object sender, EventArgs e)
        {
            // Clearing all the patient's fields
            txtPatientName.Text = "";
            dtpPatientDoB.Text = DateTime.Now.ToString();
            txtPatientAddress.Text = "";
            txtPatientCity.Text = "";
            txtPatientProvince.Text = "";
            txtPatientPostalCode.Text = "";
            txtPatientPhone.Text = "";
            txtPatientEmail.Text = "";

            // Clearing all the appointment's fields
            dtpAppointmentTime.Text = DateTime.Now.ToString();
            cboAppointmentDuration.ResetText();
            txtAppointmentPurpose.Text = "";
        }

        //====================
        // Pre-Fill Fields
        //====================
        // TODO: Add Description
        private void btnPreFillFields_Click(object sender, EventArgs e)
        {
            // Appointment appointment = AppointmentObject();

            // Prefill all the patient's fields
            txtPatientName.Text = appointment.PatientName;            
            dtpPatientDoB.Text = appointment.PatientDoB.ToString();
            txtPatientAddress.Text = appointment.PatientAddress;
            txtPatientCity.Text = appointment.PatientCity;
            txtPatientProvince.Text = appointment.PatientProvince;
            txtPatientPostalCode.Text = appointment.PatientPostalCode;
            txtPatientPhone.Text = appointment.PatientPhone;
            txtPatientEmail.Text = appointment.PatientEmail;

            // Prefill all the appointment's fields
            dtpAppointmentTime.Text = appointment.AppointmentTime.ToString();
            cboAppointmentDuration.Text = appointment.AppointmentDuration;
            txtAppointmentPurpose.Text = appointment.AppointmentPurpose;

            // Removing error messages
            lblErrorName.Text = "";
            lblErrorAge.Text = "";
            lblErrorAddress.Text = "";
            lblErrorCity.Text = "";
            lblErrorProvince.Text = "";
            lblErrorPostalCode.Text = "";
            lblErrorPhone.Text = "";
            lblErrorEmail.Text = "";
            lblErrorDuration.Text = "";
            lblErrorPurpose.Text = "";
        }

        //====================
        // Print
        //====================
        // TODO: Add Description
        private void btnPrint_Click(object sender, EventArgs e)
        {

            // TODO: Assignment Requirements
            /*
             * Print shows correct popups based on how many appointments are scheduled
             * Print outputs to a Text file called Appointments.txt
             * Print outputs ALL appointment information and in the correct format
            */

        }


        //====================
        // Input Validations & Error Messages
        //====================
        // On user change (leave the input) the data will be validated. If data doesn't meet the requirements, an error message will be displayed
        // Check if validations pass or display error messages
        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientName = txtPatientName.Text;

            // Validation using Static Class Method
            bool validatedPatientName = ValidationHelper.IsValidFullName(patientName);

            // If validation fails (returns false) an error message will be displayed            
            lblErrorName.Text = validatedPatientName ? "" : "* incorrect format";

        }

        private void dtpPatientDoB_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            DateTime patientDateOfBirth = Convert.ToDateTime(dtpPatientDoB.Text); // Convert Input Data (string) to DateTime
            
            // Validation using Static Class Method
            bool validatedPatientAge = ValidationHelper.IsValidPatientAge(patientDateOfBirth);

            // If validation fails (returns false) an error message will be displayed
            lblErrorAge.Text = validatedPatientAge ? "" : "Patient must be at least 18 years of age";
        }

        private void txtPatientAddress_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientAddress = txtPatientAddress.Text;

            // Validation using Static Class Method
            bool validatedPatientAddress = ValidationHelper.IsValidString(patientAddress);

            // If validation fails (returns false) an error message will be displayed
            lblErrorAddress.Text = validatedPatientAddress ? "" : "* can't be blank";
        }

        private void txtPatientCity_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientCity = txtPatientCity.Text;

            // Validation using Static Class Method            
            bool validatedPatientCity = ValidationHelper.IsValidString(patientCity);

            // If validation fails (returns false) an error message will be displayed
            lblErrorCity.Text = validatedPatientCity ? "" : "* can't be blank";
        }

        private void txtPatientProvince_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientProvince = txtPatientProvince.Text;

            // Validation using Static Class Method            
            bool validatedPatientProvince = ValidationHelper.IsValidString(patientProvince);

            // If validation fails (returns false) an error message will be displayed
            lblErrorProvince.Text = validatedPatientProvince ? "" : "* can't be blank";
        }

        private void txtPatientPostalCode_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientPostalCode = txtPatientPostalCode.Text;

            // Validation using Static Class Method
            bool validatedPatientPostalCode = ValidationHelper.IsValidPostalCode(patientPostalCode);

            // If validation fails (returns false) an error message will be displayed
            lblErrorPostalCode.Text = validatedPatientPostalCode ? "" : "Postal Code must be in a valid format (e.g. N3B 1C5)";
        }

        private void txtPatientPhone_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientPhone = txtPatientPhone.Text;

            // Validation using Static Class Method
            bool validatedPatientPhone = ValidationHelper.IsValidPhoneNumber(patientPhone);

            // If validation fails (returns false) an error message will be displayed
            lblErrorPhone.Text = validatedPatientPhone ? "" : "Phone number must be in a valid format (e.g. 1234567890)";
        }

        private void txtPatientEmail_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientEmail = txtPatientEmail.Text;

            // Validation using MailAddress
            bool validatedPatientEmail = ValidationHelper.IsValidEmail(patientEmail);

            // If validation fails (returns false) an error message will be displayed
            lblErrorEmail.Text = validatedPatientEmail ? "" : "Email must be provided in a valid format (e.g. test@gmail.com)";
        }

        private void cboAppointmentDuration_Leave(object sender, EventArgs e)
        {
            // Capture user's input            
            string appointmentDuration = cboAppointmentDuration.Text;

            // Validation using Static Class Method
            bool validatedAppointmentDuration = ValidationHelper.IsValidString(appointmentDuration);

            // If validation fails (returns false) an error message will be displayed
            lblErrorDuration.Text = validatedAppointmentDuration ? "" : "* can't be blank";
        }

        private void txtAppointmentPurpose_Leave(object sender, EventArgs e)
        {
            // Capture user's input            
            string appointmentPurpose = txtAppointmentPurpose.Text;

            // Validation using Static Class Method
            bool validatedAppointmentPurpose = ValidationHelper.IsValidString(appointmentPurpose);

            // If validation fails (returns false) an error message will be displayed
            lblErrorPurpose.Text = validatedAppointmentPurpose ? "" : "* can't be blank";
        }

        //====================
        // Helper Methods
        //====================


    }
}