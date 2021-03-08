using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class UserTests
    {
        [Fact]
        public void UserNameIsNull()
        {
            //Arrange
            Action act = () => new User(null, "test@test.com");
            //Act & Assert
            act.Should().Throw<ArgumentNullException>();
        }


        [Fact]
        public void UserEmailIsNull()
        {
            //Arrange
            Action act = () => new User("name", null);
            //Act & Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UserSuccess()
        {
            //Arrange
            Action act = () => new User("name", "test@test.com");
            //Act & Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
