using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Net.Mail;

namespace assignment2_DavidFlorez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //====================
        // Form Load
        //====================
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //====================
        // Book Appointment
        //====================
        // TODO: Add Description
        private void btnBookAppointment_Click(object sender, EventArgs e)
        {

            // TODO: Assignment Requirements
            /*
             * Book appointment button shows correct message popups based on if there are errors present or not, as well as a 
             * success popup outlining the appointment time
            */

            // TODO: Check into TimeSpan && its methods
            // Console.WriteLine(TimeSpan.FromMinutes); 


            // Capturing User Input
            // string patientName = txtPatientName.Text;
            // DateTime patientDateOfBirth = Convert.ToDateTime(dtpPatientDoB.Text); // Convert Input Data (string) to DateTime
            // string patientAddress = txtPatientAddress.Text;
            // string patientCity = txtPatientCity.Text;
            // string patientProvince = txtPatientProvince.Text;
            // string patientPostalCode = txtPatientPostalCode.Text;
            // string patientPhone = txtPatientPhone.Text;
            // string patientEmail = txtPatientEmail.Text;

            //--------------------
            // Validations
            //--------------------
            // Boolean declarations for returned helper methods returned values
            // bool validatedPatientName = ValidationHelper.IsValidString(patientName);
            // bool validatedPatientAge = ValidationHelper.IsValidPatientAge(patientDateOfBirth);            
            // bool validatedPatientAddress = ValidationHelper.IsValidString(patientAddress);
            // bool validatedPatientCity = ValidationHelper.IsValidString(patientCity);            
            // bool validatedPatientProvince = ValidationHelper.IsValidString(patientProvince);            
            // bool validatedPatientPostalCode = ValidationHelper.IsValidPostalCode(patientPostalCode);            
            // bool validatedPatientPhone = ValidationHelper.IsValidPhoneNumber(patientPhone);
            // bool validatedPatientEmail = ValidationHelper.IsValidEmail(patientEmail);

            // TODO: This validation needs to be refactored: String must be "First Name" + " " + "Last Name"
            /*
            if (!validatedPatientName) 
            {
                // Input has been validated - do something
            }
            
            if (validatedPatientAge) 
            {
                // Input has been validated -> do something with data   
            }

            if (!validatedPatientAddress)
            {
                // Input has been validated -> do something
            }

            if (!validatedPatientCity)
            {
                // Input has been validated -> do something
            }

            if (!validatedPatientProvince)
            {
                // Input has been validated -> do something
            }

            if (validatedPatientPostalCode)
            {
                // Input has been validated -> do something
            }

            if (validatedPatientPhone)
            {
                // Input has been validated -> do something
            }

            if (validatedPatientEmail)
            {
                // Input has been validated -> do something
            }
            */



            // Console.WriteLine("patientAgeValidated");
            // Console.WriteLine(validatedPatientAge); // >> 


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
            // cboAppointmentDuration.Text = "";
            cboAppointmentDuration.ResetText();
            txtAppointmentPurpose.Text = "";
        }

        //====================
        // Pre-Fill Fields
        //====================
        // TODO: Add Description
        private void btnPreFillFields_Click(object sender, EventArgs e)
        {

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
        // For string validations a true returned will generate an error message (if string is empty or null -> true)
        // For the other validations a false returned will generate an error message
        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientName = txtPatientName.Text;

            // Validation using Static Class Method
            bool validatedPatientName = ValidationHelper.IsValidString(patientName);
            
            // If validation fails (returns true) an error message will be displayed
            lblErrorName.Text = validatedPatientName ? "* can't be blank" : "";

        }

        private void dtpPatientDoB_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            DateTime patientDateOfBirth = Convert.ToDateTime(dtpPatientDoB.Text); // Convert Input Data (string) to DateTime
            
            // Validation using Static Class Method
            bool validatedPatientAge = ValidationHelper.IsValidPatientAge(patientDateOfBirth);

            // If validation fails (returns false) an error message will be displayed
            lblErrorAge.Text = !validatedPatientAge ? "Patient must be at least 18 years of age" : "";
        }

        private void txtPatientAddress_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientAddress = txtPatientAddress.Text;

            // Validation using Static Class Method
            bool validatedPatientAddress = ValidationHelper.IsValidString(patientAddress);

            // If validation fails (returns true) an error message will be displayed
            lblErrorAddress.Text = validatedPatientAddress ? "* can't be blank" : "";
        }

        private void txtPatientCity_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientCity = txtPatientCity.Text;

            // Validation using Static Class Method            
            bool validatedPatientCity = ValidationHelper.IsValidString(patientCity);

            // If validation fails (returns true) an error message will be displayed
            lblErrorCity.Text = validatedPatientCity ? "* can't be blank" : "";
        }

        private void txtPatientProvince_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientProvince = txtPatientProvince.Text;

            // Validation using Static Class Method            
            bool validatedPatientProvince = ValidationHelper.IsValidString(patientProvince);

            // If validation fails (returns true) an error message will be displayed
            lblErrorProvince.Text = validatedPatientProvince ? "* can't be blank" : "";
        }

        private void txtPatientPostalCode_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientPostalCode = txtPatientPostalCode.Text;

            // Validation using Static Class Method
            bool validatedPatientPostalCode = ValidationHelper.IsValidPostalCode(patientPostalCode);

            // If validation fails (returns false) an error message will be displayed
            lblErrorPostalCode.Text = !validatedPatientPostalCode ? "Postal Code must be in a valid format (e.g. N3B 1C5)" : "";
        }

        private void txtPatientPhone_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientPhone = txtPatientPhone.Text;

            // Validation using Static Class Method
            bool validatedPatientPhone = ValidationHelper.IsValidPhoneNumber(patientPhone);

            // If validation fails (returns false) an error message will be displayed
            lblErrorPhone.Text = !validatedPatientPhone ? "Phone number must be in a valid format (e.g. 1234567890)" : "";
        }

        private void txtPatientEmail_Leave(object sender, EventArgs e)
        {
            // Capture user's input
            string patientEmail = txtPatientEmail.Text;

            // Validation using MailAddress
            bool validatedPatientEmail = ValidationHelper.IsValidEmail(patientEmail);

            // If validation fails (returns false) an error message will be displayed
            lblErrorEmail.Text = !validatedPatientEmail ? "Email must be provided in a valid format (e.g. test@gmail.com)" : "";
        }

        //====================
        // Helper Methods
        //====================


    }
}