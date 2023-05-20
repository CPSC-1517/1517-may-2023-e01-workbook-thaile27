namespace OOPsReview
{
    public class Employment
    {
        // Fields or class data members
        private SupervisoryLevel _Level;
        private string _Title;
        private double _Years;

        // Properties 



        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                _Title = value;
            }
        }
        public SupervisoryLevel Level
        {
            get { return _Level; }
            private set
            {
                /* Validate the value given as an enum is actually defined
                 * 
                 * to test for a defined enum value, use Enum.IsDefined(typeof(xxxx), value)
                 * where xxxx is the name of the enum datatype
                 */
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory level is invalid: {value}");
                }
                _Level = value;
            }
        }

        // validate the years of service in the employment position as a positive value
        public double Years
        {
            get { return _Years; } // used on the right side of an assignment statement or in an expression
            set                    // used on the left side of the assigment statement or in an expression 
            {
                //if (value < 0) 
                if (!Utilities.IsZeroOrPositive(value))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _Years = value;
            }
        }

        /* This property is an example of an auto-implemented property, 
         * there is no validation within the property,
         * there is NO private data member for this property
         * the system will generate an internal storage area for the data
         *      and handle the setting and getting from that storage area
         * the private set means that the property will only be able to be 
         *      set via a constructor or method. 
         * auto-implemented properties can have either a public or private set 
         * using a public or private set is a design decision 
         */
        public DateTime StartDate { get; private set; }



        // Constructors
        //
        // the purpose of a constructor is to create an instance of your class
        //      in a known state.
        //does a class definition need a constructor? NO.
        //   if a class definition does NOT have a constructor then the system
        //   will create the instance and assign the system default value to data member
        //   and/or auto implemented property
        //   if you have no constructor the common phrase is "using a system constructor"
        //
        //IF YOU CODE A CONSTRUCTOR IN YOUR CLASS YOU ARE RESPONSIBLE FOR ANY AND ALL CONSTRUCTORS
        //FOR THE CLASS!!!


        //"default" constructor
        //you can apply your own literal values for your data members and/or auto-implemented properties
        //  that differ from the system default values
        //why? you may have data that is validated and using the system default values would cause an
        //  exception
        public Employment()
        {
            // this constructor will be used on creating an instance using
            // Employment myInstance = new Employment();
            // A practice that I personally use is to avoid referring to my data memebers directly
            // Specially if the property contains validation 

            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
            // Optionally one could set yours to zero, but that is the system default
            // value for a numeric, therefore one does not need to assign a value 
            // UNLESS you wish to 

        }

        //greedy constructor
        //a greedy constructor is one that accepts a parameter list of values to
        //  assign to your instance data on creation of the instance
        //generally your greedy constructor constains a parameter on the signature
        //  for each data member you have in your class definition

        //all default parameters must appear AFTER non-default parameters in your parameter list
        //in this example, we will use Years as an default parameter

        // In this example, we will use Years as an default parameter
        public Employment(string title, SupervisoryLevel level, DateTime startDate, double year = 0.0)
        {
            Title = title;
            Level = level;
            Years = year;

            //this example to demonstrating where you can place validation for
            //  properties have are auto-implemented
            //validate start data must not exist in the future
            //validation can be done anywher in your class
            //since the property is auto-implemented AND has a privat set
            //      validation can be done in the constructor OR a method
            //      that alters the property value
            //IF the validation is done in the property, IT WOULD NOT be an
            //      auto-implemented property BUT a fully-implemented property
            //.Today has a time of 00:00:000 AM
            //.Now has a specific time of day at execution 18:47:256 PM
            //by using the .Today.AddDays(1) you cover all times on a specific date

            if (startDate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startDate} is in the future");
            }
            StartDate = startDate;

        }

        // Methods
        // Behaviours (aka methods)
        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            // the property has a private set
            // Therefore the only way to assign a value to the property 
            //      is either: via the constructor at creation time
            //      or: via a public method within the class

            // What about validating the value? 
            // Validation can be done in multiple places
            // a. can it be done in the method? Y
            // b. can it be done in the property? Y if property is fully implemented

            Level = level;
        }
        public void CorrectStartDate(DateTime startDate)
        {
            // the StartDate property is an auto implemented property
            // The startDate property has no Validation code
            // You need to do any validation on incoming value wherever you plan to alter the existing value in the class

            if (startDate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startDate} is in the future");
            }
            StartDate = startDate;
        }
        public override string ToString()
        {
            return $"{_Title}, {_Level}";
        }


    }
}