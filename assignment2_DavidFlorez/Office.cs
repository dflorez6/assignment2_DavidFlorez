using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_DavidFlorez
{
    // Class
    public class Office
    {
        //====================
        // Fields or Properties
        //====================
        // * Office object has private member variable Appointments
        private List<Appointment> _appointments;

        //====================
        // Constructors
        //====================
        // Default
        public Office()
        {
            _appointments = new List<Appointment>();
        }

        //====================
        // Methods
        //====================
        // ShowAppointments: Static Method
        // Accepts: ??
        // Returns: List<Appointment>
        // Description: TODO
        public List<Appointment> ShowAppointments()
        {
            return _appointments;
        }

        // ShowAppointments: Static Method
        // Accepts: ??
        // Returns: List<Appointment>
        // Description: TODO
        public int NumberOfAppointments()
        {
            return _appointments.Count;
        }

        // BookAppointment: Static Method
        // Accepts: Appointment
        // Returns: void
        // Description: TODO
        public void BookAppointment(Appointment appointment)
        {
            // Initial Declarations
            DateTime newAppointmentTime = appointment.AppointmentTime;
            DateTime newAppointmentEndTime = appointment.AppointmentEndTime;


            /*
            Console.WriteLine("Appointment Time");
            Console.WriteLine(appointmentTime);
            Console.WriteLine(appointmentDuration);
            Console.WriteLine(appointmentDurationIndex);
            Console.WriteLine(appTime);

            Console.WriteLine("appointmentTimeEnd");
            Console.WriteLine(appointmentTimeEnd);
            // Console.WriteLine(durationInMinutes);
            */


            // Validates previously booked appointments
            // If true: no validations required Add new appointment to Instance._appointments
            // If false: validates that new appointment will not overlap with existing appointment
            if (_appointments.Count == 0)
            {
                // No appointments booked yet
                // Add appointment record
                _appointments.Add(appointment);
            }
            else
            {
                // Appointments previously booked                
                // Creates a variable that stores the result of calling the method .Exists() on the list of _appointments                
                bool isNewAppointmentOverlapping = _appointments.Exists(app => newAppointmentTime >= app.AppointmentTime && newAppointmentTime <= app.AppointmentEndTime);

                // Validates if the new appointment overlaps with any previously booked appointments
                // If true: A MessageBox will be shown to notify user of the problem
                // If false: The new appointment will be booked
                if (isNewAppointmentOverlapping)
                {
                    // New appointment overlaps with existing appointment
                    MessageBox.Show("That appointment time conflicts with another patient. Please select a different time.", "Time Conflict", MessageBoxButtons.OK);
                }
                else
                {
                    // Add appointment record
                    _appointments.Add(appointment);
                }


            }


            // TODO: NOT YET UNCOMMENT LATER
            /*
            Console.WriteLine("Office Object appointment OFFICE-----------");
            foreach (var item in ShowAppointments())
            {
                Console.WriteLine(item.PatientName);
            }
            */

        }

        // AppointmentToString: Virtual Instance Method
        // Accepts: Appointment Object
        // Returns: string
        // Description: TODO
        public virtual string AppointmentToString(Appointment appointment)
        {
            return "";
        }


    }

}

// TODO: Assignment Requirements
/*
 
 * Office object has a Book Appointment method that ensures appointment time doesn't conflict with an already scheduled appointment
*/



/*
 
//====================
// Creating Instances (objects) // Using Class
//====================
// from where I want to call it for example
// Form Load 
private void Form1_Load(object sender, EventArgs e)
{
    // Create Instance 
    ClassName instanceName = new ClassName(); // creates new instance/object with default constructor
    ClassName instanceName = new ClassName(argument1, argument2); // creates new instance/object with other constructor
                   
    // Update Property Values (setter)
    instanceName.Property = value;

    // Update Static Property Values (setter)
    ClassName.Property = value;

    // Calling Methods
    instanceName.Method(); // Instance Method
    ClassName.Method(); // Static / Class Method
}

*/
