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

            string expectedLastName = "smith";

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

        [InlineData("   ")]
        [InlineData("Hai")]
        public void Throw_Exception_When_Setting_FirstName_To_Missing_Data(string firstName)
        {
            // Arrange (setup)
            string lastName = "Le";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person("unknown", lastName, address, null);
            string expectedFirstName = "unknown";

            // Act (execution) (sut = subject under test)
            Action action = () => new Person(firstName, lastName, address, null);

            // Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }


        #endregion

    }
}