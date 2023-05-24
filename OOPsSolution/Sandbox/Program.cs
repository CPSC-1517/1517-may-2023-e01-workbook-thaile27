using OOPsReview;
internal class Program
{
    static void Main(string[] args)
    {
        Residence myHome = new(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
        Console.WriteLine(myHome.ToString());

        // Can i change a value in the record instance? NO!
        //myHome.Number = 321;

        // To alter the value in the record instance you MUST create new a new instance
        myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
        Console.WriteLine(myHome.ToString());
    }
}
