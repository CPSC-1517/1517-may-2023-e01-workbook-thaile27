using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    // Attribute title
    // Fact which does one test and is usually setup and coded within the test
    // Theory which allow for multiple test data stream applied to the same test

    public class Person_Should
    {
        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name()
        {
            // Arrange (setup)
            string firstName = "Hai";
            string lastName = "Le";

            // Act (execution) (sut = subject under test)
            Person sut = new Person(firstName, lastName);

            // Assert (testing of the action)
            sut._firstName.Should().Be(firstName);
            sut._lastName.Should().Be(lastName);
        }
    }
}