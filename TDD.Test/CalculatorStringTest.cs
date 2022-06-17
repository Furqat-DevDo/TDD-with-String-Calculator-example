
using FluentAssertions;
using Xunit;

namespace TDD.Test
{
    public  class CalculatorStringTest
    {
        [Theory]
        [InlineData("",0)]
        [InlineData(null,0)]
        public void if_string_empty_or_null(string numbers,int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var result = sut.Add(numbers);
            //Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("#%#&@*!", "#%#&@*!")]
        [InlineData("Aznqwjdkwefjipmoger", "Aznqwjdkwefjipmoger")]
        public void if_string_isnotValid_number(string numbers, string expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            Action action = ()=> sut.Add(numbers);
            //Assert
            action.Should().ThrowExactly<ArgumentException>(nameof(expected));
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("0", 0)]
        public void if_string_isSingle_number(string numbers, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var result = sut.Add(numbers);
            //Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,2,3 4", 10)]
        [InlineData("2 56 67,89,09", 223)]
        [InlineData("0,45,6", 51)]
        public void if_string_isMultiple_numbers(string numbers, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var result = sut.Add(numbers);
            //Assert
            result.Should().Be(expected);
        }
    }
}
