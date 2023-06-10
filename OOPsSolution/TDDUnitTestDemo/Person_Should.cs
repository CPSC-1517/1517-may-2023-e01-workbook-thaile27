using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    // Attribute title
    // Fact which does one test and is usually setup and coded within the test
    // Theory which allow for multiple test data stream applied to the same test

    public class Person_Should
    {
        public Person Make_SUT_Instance()
        {
            string firstName = "Hai";
            string lastName = "Le";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person sut = new Person(firstName, lastName, address, null);

            return sut;
        }

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
            Person me = Make_SUT_Instance();

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
            Person me = Make_SUT_Instance();

            string expectedLastName = "Smith";

            // Act (execution) (sut = subject under test)
            me.FirstName = expectedLastName;

            // Assert (testing of the action)
            me.FirstName.Should().Be(expectedLastName);
        }
        [Fact]
        public void Change_Both_First_And_Last_Name_To_New_Name()
        {
            // Arrange
            Person sut = Make_SUT_Instance();
            string expectedFirstName = "bob";
            string expectedLastName = "smith";

            // Act
            sut.ChangeName(expectedFirstName, expectedLastName);

            // Assert
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);

        }
        [Fact]
        public void Return_The_FullName_Of_The_Person()
        {
            // Arrange
            Person sut = Make_SUT_Instance();
            string expectedFullName = "Hai, Le";

            // Act
            string actual = sut.FullName;

            // Assert
            actual.Should().Be(expectedFullName);
        }
        [Fact]
        public void Return_The_Number_Of_Employment_Instances_For_New_Person()
        {
            // Arrange
            Person sut = Make_SUT_Instance();

            // Act
            int actual = sut.NumberOfEmployments;

            // Assert
            actual.Should().Be(0);
        }

        [Fact]
        public void Add_First_Employment_Instance()
        {
            // Arrange
            Person sut = Make_SUT_Instance();

            int expectedNumberOfEmployment = 1;

            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 05, 10));

            // Act
            sut.AddEmployment(employment);

            // Assert
            sut.NumberOfEmployments.Should().Be(expectedNumberOfEmployment);
            sut.EmploymentPositions[0].ToString().Should().Be(employment.ToString());
        }
        [Fact]
        public void Add_Another_Employment_Instance()
        {
            //Arrange (setup)
            //no employment instances

            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");

            List<Employment> employments = new List<Employment>();
            Employment emp1 = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2016, 03, 10));
            Employment emp2 = new Employment("TDD Lead", SupervisoryLevel.TeamLeader, new DateTime(2020, 03, 10));
            employments.Add(emp1);
            employments.Add(emp2);
            Person sut = new Person(firstname, lastname, address, employments);

            Employment employment = new Employment("TDD Supervisor", SupervisoryLevel.Supervisor, new DateTime(2023, 03, 10));

            int expectednumberofemployment = 3;
            List<Employment> expectedemployments = new List<Employment>()
            {
                emp1,
                emp2,
                employment
            };

            //Act (execution)
            sut.AddEmployment(employment);


            //Assert (testing of the action)
            sut.NumberOfEmployments.Should().Be(expectednumberofemployment);
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedemployments);
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
            Person me = Make_SUT_Instance();

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
            Person me = Make_SUT_Instance();

            // Act (execution) (testing will the property capture an invalid name change)
            // Action is a special unit testing data type that records the results of the executed statement into variable action
            // Assignment operator '='
            // () => for the following code execution
            // me.FirstName = changeName is actual action that is being tested as if it were really in a program

            Action action = () => me.LastName = changeName;

            // Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null, "Le")]
        [InlineData("Hai", null)]
        [InlineData("", "Le")]
        [InlineData("Hai", "")]
        [InlineData("   ", "Le")]
        [InlineData("Hai", "   ")]
        public void Throw_Exception_When_Changing_First_And_Last_Name_With_Missing_Data(string newFirstName, string newLastName)
        {
            // Arrange
            Person sut = Make_SUT_Instance();

            // Act
            Action action = () => sut.ChangeName(newFirstName, newLastName);

            // Assert
            action.Should().Throw<ArgumentNullException>().WithMessage("*is required*");
        }
        [Fact]
        public void Throw_Exception_When_Adding_Null_Employment_Instance()
        {
            // Arrange
            Person sut = Make_SUT_Instance();
            int expectedNumberOfEmployment = 1;

            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 05, 10));

            // Act
            Action action = () => sut.AddEmployment(null);

            // Assert
            action.Should().Throw<ArgumentNullException>().WithMessage("*required*");
        }
        #endregion

    }
}