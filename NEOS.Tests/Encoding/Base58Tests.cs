using System;
using System.Linq;
using Xunit;
using NEOS.Encoding;
using NEOS.Extensions;

namespace NEOS.Tests.Encoding
{
    public class Base58Tests
    {
        private (string data, string result)[] testData = new(string data, string result)[] {
            ("0044D00F6EB2E5491CD7AB7E7185D81B67A23C4980F62B2ED0914D32B7EB1C558104787746", "1XJjHG4gLiJfxrx82yPFWC8tu8cxKvaQjZNvVfSrsfiX4mbUsw")
        };

        [Fact]
        public void Base58EncodeTest()
        {
            foreach (var testPair in testData)
                Assert.Equal(testPair.result, Base58.Encode(testPair.data));
        }

        [Fact]
        public void Base58DecodeTest()
        {
            foreach (var testPair in testData)
                Assert.Equal(testPair.data.ToBytes(), Base58.Decode(testPair.result));
        }
    }
}
