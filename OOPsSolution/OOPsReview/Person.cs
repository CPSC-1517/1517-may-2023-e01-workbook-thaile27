namespace OOPsReview
{
    public class Person
    {
        // fields
        private string _FirstName;
        private string _LastName;

        // Properties
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("first name is required");
                }
                _FirstName = value;
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("last name is required");
                }
                _LastName = value;
            }
        }
        public Residence Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public Person(string firstName, string lastName, Residence address, List<Employment> employmentPositions)
        {
            //if (string.IsNullOrWhiteSpace(firstName))
            //{
            //    throw new ArgumentNullException(nameof(firstName), "first name is required");
            //}
            //if (string.IsNullOrWhiteSpace(lastName))
            //{
            //    throw new ArgumentNullException(nameof(lastName), "last name is required");
            //}
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            if (employmentPositions != null)
            {
                EmploymentPositions = employmentPositions; // store the supplied list of employments
            }
            //else
            //{
            //    EmploymentPositions = new List<Employment>(); // create an empty instance of the list
            //}
        }

        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";
            //EmploymentPositions = new List<Employment>();
        }
    }
}
