using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    // Attribute title
    // Fact which does one test and is usually setup and coded within the test
    // Theory which allow for multiple test data stream applied to the same test

    public class Person_Should
    {
        #region Valid data
        [Fact]
        public void Create_an_Instance_Using_Default_Constructor()
        {
            // Arrange
            string expectedFirstName = "unknown";
            string expectedLastName = "unknown";

            // Act
            Person sut = new Person();

            // Assert
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }
        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name_Residence_With_NO_List_Of_Employment()
        {
            // Arrange (setup)
            string firstName = "Hai";
            string lastName = "Le";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "123,Maple St.,Edmonton,AB,T6Y7U8";


            // Act (execution) (sut = subject under test)
            Person sut = new Person(firstName, lastName, address, null);

            // Assert (testing of the action)
            sut.FirstName.Should().Be(firstName);
            sut.LastName.Should().Be(lastName);
            sut.Address.ToString().Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }
        [Fact]
        public void Change_FirstName_to_New_Name()
        {
            // Arrange (setup)
            string firstName = "Hai";
            string lastName = "Le";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person("unknown", lastName, address, null);

            string expectedFirstName = "bob";

            // Act (execution) (sut = subject under test)
            me.FirstName = expectedFirstName;

            // Assert (testing of the action)
            me.FirstName.Should().Be(expectedFirstName);
        }
        [Fact]
        public void Change_LastName_to_New_Name()
        {
            // Arrange (setup)
            string firstName = "Hai";
            string lastName = "Le";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person("unknown", lastName, address, null);

            string expectedLastName = "Smith";

            // Act (execution) (sut = subject under test)
            me.FirstName = expectedLastName;

            // Assert (testing of the action)
            me.FirstName.Should().Be(expectedLastName);
        }
        #endregion

        #region Invalid data
        [Theory]
        [InlineData(null, "Le")]
        [InlineData("Hai", null)]
        [InlineData("", "Le")]
        [InlineData("Hai", "")]
        [InlineData("   ", "Le")]
        [InlineData("Hai", "   ")]
        public void Create_a_Greedy_Instance_With_No_Names_Throws_Exceptions(string firstName, string lastName)
        {
            // Arrange (setup)
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "123,Maple St.,Edmonton,AB,T6Y7U8";

            // Act (execution) (sut = subject under test)
            Action action = () => new Person(firstName, lastName, address, null);

            // Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_When_Setting_FirstName_To_Missing_Data(string changeName)
        {
            // Arrange (setup)
            string lastName = "Le";
            string firstName = "Hai";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstName, lastName, address, null);

            // Act (execution) (testing will the property capture an invalid name change)
            // Action is a special unit testing data type that records the results of the executed statement into variable action
            // Assignment operator '='
            // () => for the following code execution
            // me.FirstName = changeName is actual action that is being tested as if it were really in a program

            Action action = () => me.FirstName = changeName;

            // Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_When_Setting_LastName_To_Missing_Data(string changeName)
        {
            // Arrange (setup)
            string firstName = "Hai";
            string lastName = "Le";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstName, lastName, address, null);

            // Act (execution) (testing will the property capture an invalid name change)
            // Action is a special unit testing data type that records the results of the executed statement into variable action
            // Assignment operator '='
            // () => for the following code execution
            // me.FirstName = changeName is actual action that is being tested as if it were really in a program

            Action action = () => me.LastName = changeName;

            // Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }

        #endregion

    }
}