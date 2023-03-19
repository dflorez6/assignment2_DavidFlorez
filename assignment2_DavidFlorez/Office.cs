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
        // Fields
        //====================
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
        // BookAppointment: Instance Method
        // Accepts: Appointment Object
        // Returns: void
        // Description: The method receives an appointment object. It first checks if there are any appointment booked.
        // If there are no appointments previously booked: The method will book the appointment and will display a success message
        // If there are appointments previously booked: using .Exists List<T> Method to verify if the new appointment that the user is
        // trying to book doesn't overlap with an existing appointment. .Exists returns a boolean, so the control flow will
        // display an error message if the new appointment overlaps with an existing appoint. If the new appointment doesn't overlap,
        // the method will book the appointment and will display a success message
        public void BookAppointment(Appointment appointment)
        {
            // Initial Declarations
            DateTime newAppointmentTime = appointment.AppointmentTime;
            DateTime newAppointmentEndTime = appointment.AppointmentEndTime;

            // Validates previously booked appointments
            // If true: no validations required Add new appointment to Instance._appointments
            // If false: validates that new appointment will not overlap with existing appointment
            if (_appointments.Count == 0)
            {
                // No appointments booked yet
                // Add appointment record
                _appointments.Add(appointment);

                // Succesful appointment booked displays confirmation message
                MessageBox.Show($"Succesfully booked your appointment on {appointment.AppointmentTime.ToString("MM-dd-yyyy")} at {appointment.AppointmentTime.ToString("H:mm")}", "Time Conflict", MessageBoxButtons.OK);
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
                    // New appointment overlaps with existing appointment will raise an error message
                    MessageBox.Show("That appointment time conflicts with another patient. Please select a different time.", "Time Conflict", MessageBoxButtons.OK);
                }
                else
                {
                    // Add appointment record
                    _appointments.Add(appointment);

                    // Succesful appointment booked displays confirmation message
                    MessageBox.Show($"Succesfully booked your appointment on {appointment.AppointmentTime.ToString("MM-dd-yyyy")} at {appointment.AppointmentTime.ToString("H:mm")}", "Time Conflict", MessageBoxButtons.OK);
                }
            }
        }

        // AppointmentToString: Virtual Instance Method
        // Accepts: Appointment Object
        // Returns: string
        // Description: This method is needed to have an override method in the Appointment Class
        public virtual string AppointmentToString(Appointment appointment)
        {
            return "";
        }


        //====================
        // Helper Methods
        //====================
        // ReturnAppointments: Instance Method
        // Accepts: No parameters
        // Returns: List<Appointment>
        // Description: Returns a list of all the booked appointments
        public List<Appointment> ReturnAppointments()
        {
            return _appointments;
        }

        // NumberOfAppointments: Instance Method
        // Accepts: No parameters
        // Returns: int
        // Description: Returns the number of appointments booked (0 or more). Used for control flow in the Print Button
        public int NumberOfAppointments()
        {
            return _appointments.Count;
        }

    }

}