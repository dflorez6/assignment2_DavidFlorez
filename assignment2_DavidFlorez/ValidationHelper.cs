using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace assignment2_DavidFlorez
{
    // ValidationHelper
    // Methods: All Methods are Static
    public class ValidationHelper
    {
        //====================
        // Methods
        //====================
        // IsValidPatientAge: Static Method
        // Accepts: DateTime
        // Returns: Boolean
        // Description: Method checks if the patient is at least 18 years old && prevents users from entering dates in the future as input
        public static bool IsValidPatientAge(DateTime dateOfBirth)
        {
            // Initial Declarations
            const double MINIMUM_AGE = 18;
            const double DAYS_IN_A_YEAR = 365.242199; // This constant is the actual number of days within a year

            // Calculate current age
            double currentAge = ((DateTime.Now - dateOfBirth).TotalDays) / DAYS_IN_A_YEAR;

            // Validates dateOfBirth (DateTime)
            // Returns true if dateOfBirth is less than current DateTime && the patient's current age is
            // greater than or equal than the minimum age.
            // Returns false if conditions are not met.
            if (dateOfBirth < DateTime.Now && currentAge >= MINIMUM_AGE)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        // IsValidPostalCode: Static Method
        // Accepts: String
        // Returns: Boolean
        // Description: Method checks if a postal code passed as a string is in the correct format by matching a Regex pattern
        public static bool IsValidPostalCode(string postalCode)
        {
            // Regex
            string pattern = @"^[ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ][\s-]?\d[ABCEGHJKLMNPRSTVWXYZ]\d$"; // Regex Canada Postal Code

            // Validation
            if (Regex.IsMatch(postalCode, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // IsValidPhoneNumber: Static Method
        // Accepts: String
        // Returns: Boolean
        // Description: Method checks if a phone number passed as a string is in the correct format by matching a Regex pattern
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // TODO: Assignment Requirements
            /*
             * Uses a Regex to perform the validation
             * Returns false if the string is null/empty/mismatches; true if whole matches the pattern
            */

            // Regex
            string pattern = @"^\d{10}$"; // Regex 10 digit only numbers

            // Validation
            if (Regex.IsMatch(phoneNumber, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // IsValidEmail: Static Method
        // Accepts: String
        // Returns: Boolean
        // Description: Method checks if an email address passed as a string is in the correct format by using MailAddress Class
        public static bool IsValidEmail(string email)
        {
            // Validation using MailAddress (prebuilt)
            try
            {
                MailAddress validatedPatientEmail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // IsValidString: Static Method
        // Accepts: String
        // Returns: Boolean
        // Description: Method checks if a string passed is not null or empty
        public static bool IsValidString(string patientInput)
        {
            // Validation
            if (string.IsNullOrEmpty(patientInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}