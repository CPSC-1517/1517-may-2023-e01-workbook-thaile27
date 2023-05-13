namespace OOPsReview
{
    public class Employment
    {
        // Fields or class data members
        private SupervisoryLevel _Level;
        private string _Title;
        private double _Years;

        // Properties 
        public SupervisoryLevel Level
        {
            get { return _Level; }
            set { _Level = value; }
        }

        public DateTime StartDate { get; set; }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                else
                {
                    _Title = value;
                }
            }
        }

        public double Years
        {
            get { return _Years; }
            set { _Years = value; }
        }

        // Methods
        public void CorrectStartDate(DateTime startDate)
        {

        }
        public Employment()
        {

        }
        public Employment(string title, SupervisoryLevel level, DateTime startDate, double year = 0.0)
        {
            Title = title;
            Level = level;
            StartDate = startDate;
            Years = year;
        }
        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {

        }
        public override string ToString()
        {
            return $"{_Title}, {_Level}";
        }


    }
}