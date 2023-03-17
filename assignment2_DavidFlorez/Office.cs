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
    public class Office
    {
        //====================
        // Fields or Properties
        //====================
        private List<Appointment> _appointments; // attribute or field

        //====================
        // Constructors
        //====================
        // Default
        public Office()
        {

        }

        // Non-default
        public Office(int attributeName, string property, int staticProperty)
        {

        }

        //====================
        // Methods
        //====================
        // Instance Method
        public void InstanceMethod()
        {
          //  Console.WriteLine(this._attributeName); // Prints instance._attribute_name
        }

        // Class / Static Method
        public static void ClassMethod()
        {
          //  Console.WriteLine(Office.StaticProperty); // Prints Class.Property
        }

    }

}

// TODO: Assignment Requirements
/*
 * Office object has private member variable Appointments
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
