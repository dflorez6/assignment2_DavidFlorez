using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
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
        private List<Appointment> _appointments; // attribute or field

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
        // ShowAppointments: Instance Method
        // Accepts: ??
        // Returns: List<Appointment>
        // Description: 
        public List<Appointment> ShowAppointments()
        {
            return _appointments;
        }

        public int NumberOfAppointments()
        {
            return _appointments.Count;
        }

        // BookAppointment: Instance Method
        // Accepts: Appointment
        // Returns: void
        // Description: 
        public void BookAppointment(Appointment appointment)
        {
            Console.WriteLine("BookAppointment Method--------");
            Console.WriteLine(appointment);
            Console.WriteLine(appointment.PatientName);
            Console.WriteLine(appointment.GetType());

            // Adds appointment
            _appointments.Add(appointment);
        }

        // AppointmentToString: Virtual Instance Method
        // Accepts: Appointment Object
        // Returns: string
        // Description:
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
