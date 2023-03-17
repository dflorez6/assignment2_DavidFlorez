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
    public class Appointment
    {
        //====================
        // Attributes or properties
        //====================        
        public string Property { get; set; } // getters & setters

        //====================
        // Constructors
        //====================
        // Default
        public Appointment()
        {

        }

        // Non-default
        public Appointment(string property)
        {            
            Property = property;            
        }

        //====================
        // Methods
        //====================
        // Instance Method
        public void InstanceMethod()
        {
            Console.WriteLine(Property); // Prints instance._attribute_name
        }

    }

}

// TODO: Assignment Requirements
/*
 * Appointment object has member variables for all user-entered inputs
 * Appointment object has a ToString() override method
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
