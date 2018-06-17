using System;
using System.Linq;
using Xunit;
using NEOS.Encoding;

namespace NEOS.Tests.Encoding
{
    public class Base58CheckTests
    {
        private (Base58CheckData data, string result)[] testData = new(Base58CheckData data, string result)[] {
            (new Base58CheckData("00", "44D00F6EB2E5491CD7AB7E7185D81B67A23C4980F62B2ED0914D32B7EB1C5581"), "1XJjHG4gLiJfxrx82yPFWC8tu8cxKvaQjZNvVfSrsfiX4mbUsw")
        };

        [Fact]
        public void Base58CheckEncodeTest()
        {
            foreach (var testPair in testData)
                Assert.Equal(testPair.result, Base58Check.Encode(testPair.data.Version, testPair.data.Payload));
        }
    }
}
