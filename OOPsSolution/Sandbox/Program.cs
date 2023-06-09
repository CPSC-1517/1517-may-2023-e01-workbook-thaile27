// See https://aka.ms/new-console-template for more information
using OOPsReview;
using System.Text.Json;

Console.WriteLine("Hello, World!");

//driver code
//RecordSamples();
//RefactorSample();
//FileIOCSV();

// explore JSon files writing and reading
// create a Person instance with name, adderss and employments 
Person me = new Person();
DisplayPerson(me);

//file path C:\Temp\EmploymentData.json
string filepathname = @"C:\Temp\EmploymentData.json";

SaveAsJson(me, filepathname);
Person CreatePerson()
{
    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    List<Employment> employments = Read_Employment_Collection_From_CSV();
    Person person = new Person("Hai", "Le", myHome, employments);
    return person;
}
void DisplayPerson(Person person)
{
    Console.WriteLine("\nPerson Data\n");
    Console.WriteLine($"Name: {person.FullName}");
    Console.WriteLine($"Residence: {person.Address.ToString()}");
    Console.WriteLine("\nEmployments");

    foreach (var item in person.EmploymentPositions)
    {
        Console.WriteLine($"\t{item.ToString()}");
    }
}
void SaveAsJson(Person person, string filepathname)
{
    // the term used to write Json files is Serialization
    // the classes used are referred to as serializers
    // with writing we can make the file produce more readable format
    // using identation
    // Json is very good at using objects and properties; 
    // However, it needs help/prompting to work better with fields
    //      to help with public fields declaration within a class, add an annotation (attributes title)
    //      in front of the field declaration called [JsonInclude]
    //      also the namespace: using System.Text.Json.Serialization;
    //      example: Assume class has a public string called FieldNotAProperty
    //      [JsonInclude]
    //      public string FieldNotAProperty

    // create options to use during serialization 
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        // During this instance creation, you can refer to properties
        // within the class directly by name and assign a value to that properties
        WriteIndented = true,
        IncludeFields = true // this is for the public non property fields of a class
    };

    // remember to case to the Serialize<T> to the appropriate class definition
    // this converts your instance to a join string

    string jsonstring = JsonSerializer.Serialize(person, options);

    // write the json string out to a .json text file 
    File.WriteAllText(filepathname, jsonstring);

}

void FileIOCSV()
{

    //create a collection of Employment instances to write out the data
    List<Employment> employments = new List<Employment>();
    employments.Add(new Employment("SAS Member", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamMember"), DateTime.Parse("2015/06/14"), 3.6));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamLeader"), DateTime.Parse("2019/01/24"), 2.8));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "Supervisor"), DateTime.Parse("2021/09/24"), 1.8));

    DumpEmployments(employments);

    Write_Employment_Collection_To_CSV(employments);

    List<Employment> employmentsRead = new List<Employment>();
    employmentsRead = Read_Employment_Collection_From_CSV();

    DumpEmployments(employmentsRead);
}
List<Employment> Read_Employment_Collection_From_CSV()
{
    //use the File class to append text records into a file
    //by using the File class one does not need to setup file IO stream
    //   File IO streams (Writer and Reader) are built into the methods of the File class
    //   

    //file path C:\Temp\EmploymentData.txt
    string filepathname = @"C:\Bob\EmploymentData.txt";

    Employment employmentInstance = null;
    List<Employment> employmentCollection = new List<Employment>();

    try
    {
        //ReadAllLines
        //returns an array of all lines from a file as strings
        string[] employmentCSVStrings = File.ReadAllLines(filepathname);

        //convert each string from the CSV data into an Employment Instance
        //use the .Parse from this action

        foreach (string line in employmentCSVStrings)
        {
            try
            {
                employmentInstance = Employment.Parse(line);
                employmentCollection.Add(employmentInstance);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return employmentCollection;

}
void Write_Employment_Collection_To_CSV(List<Employment> employments)
{
    //use the File class to append text records into a file
    //by using the File class one does not need to setup file IO stream
    //   File IO streams (Writer and Reader) are built into the methods of the File class
    //   

    //file path C:\Temp\EmploymentData.txt
    string filepathname = @"C:\Temp\EmploymentData.txt";

    //convert List<Employment> into a List<string>
    List<string> employmentCollectionAsStrings = new List<string>();
    foreach (Employment employment in employments)
    {
        employmentCollectionAsStrings.Add(employment.ToString());
    }

    //.AppendAllLines
    File.AppendAllLines(filepathname, employmentCollectionAsStrings);
}
void DumpEmployments(List<Employment> employments)
{
    Console.WriteLine("\n\t\tDump of employment instances\n");
    for (int i = 0; i < employments.Count; i++)
    {
        Console.WriteLine($"Instance {i}:\t {employments[i].ToString()}");
    }
}
void RecordSamples()
{
    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());

    //can i change a value in the record instance? NO!
    //myHome.Number = 321;

    //to alter a value in the record instance you MUST create a new instance
    myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());
}
void RefactorSample()
{
    //example of refactoring
    //Refactoring is the process of restructing code, while not
    //      changing it original functionality.The goal of refactoring
    //      is to improve internal code by making small changes without altering
    //      the codes external behaviour.

    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    //orignal code
    bool flag = false;
    if (myHome.Province.ToLower() == "ab")
    {
        flag = true;
    }
    if (myHome.Province.ToLower() == "bc")
    {
        flag = true;
    }
    if (myHome.Province.ToLower() == "sk")
    {
        flag = true;
    }
    if (myHome.Province.ToLower() == "mn")
    {
        flag = true;
    }

    if (myHome.Province.ToLower() == "ab" ||
        myHome.Province.ToLower() == "bc" ||
        myHome.Province.ToLower() == "sk" ||
        myHome.Province.ToLower() == "mn")
    {
        flag = true;
    }

    //refactor using a switch statement
    switch (myHome.Province.ToLower())
    {
        case "ab":
        case "bc":
        case "sk":
        case "mn":
        {
            flag = true;
            break;
        }
        default:
        {
            flag = false;
            break;
        }
    }

    //what would a person need to do if unit testing does not exists
    string firstname = "don";
    string lastname = "welch";
    Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Person me = new Person(firstname, lastname, address, null);

    //conside doing a loop where I make changes to the "changename", include try catch error handling
    //also need a interface of Console prompt and read lines.

    //me.FirstName = changename;
}