using System.Collections.Generic;
using Xunit;


namespace IronCodingChallenge_Test
{
    public class IronTestCase
    {
        [Fact]
        public void SingleKey_ShouldReturnA()
        {
            var input = new List<string> { "2" };
            var result = irontest.Decode(input);
            Assert.Equal("A", result);
        }

        [Fact]
        public void MultiTap_ABC()
        {
            var input = new List<string> { "2", "22", "222" };
            var result = irontest.Decode(input);
            Assert.Equal("ABC", result);
        }

        [Fact]
        public void HelloTest()
        {
            var input = new List<string> { "44", "33", "555", "555", "666" };
            var result = irontest.Decode(input);
            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void HandlesSpaceAndWrap()
        {
            var input = new List<string> { "7777", "0", "2222" };
            var result = irontest.Decode(input);
            Assert.Equal("S A", result);
        }

        [Fact]
        public void BackspaceSimulated()
        {
            var input = new List<string> { "2", "22", "222" };
            input.RemoveAt(input.Count - 1); // simulating backspace
            var result = irontest.Decode(input);
            Assert.Equal("AB", result);
        }
    }
}