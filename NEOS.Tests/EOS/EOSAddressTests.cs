using System;
using System.Linq;
using Xunit;
using NEOS.EOS;
using NEOS.Key;
using NEOS.Encoding;
using NEOS.Extensions;

namespace NEOS.Tests.Encoding
{
    public class EOSAddressTests
    {
        private (string privKey, string address)[] testData = new(string, string)[] {
            ("5JS9bTWMc52HWmMC8v58hdfePTxPV5dd5fcxq92xUzbfmafeeRo", "EOS8HuvjfQeUS7tMdHPPrkTFMnEP7nr6oivvuJyNcvW9Sx5MxJSkZ"),
            ("5KgKxmnm8oh5WbHC4jmLARNFdkkgVdZ389rdxwGEiBdAJHkubBH", "EOS7pscBeDbJTNn5SNxxowmWwoM7hGj3jDmgxp5KTv7gR89Ny5ii3"),
            ("5JFLPVygcZZdEno2WWWkf3fPriuxnvjtVpkThifYM5HwcKg6ndu", "EOS833HgCT3egUJRDnW5k3BQGqXAEDmoYo6q1s7wWnovn6B9Mb1pd")
        };

        [Fact]
        public void AddressStringTest()
        {
            foreach (var testPair in testData)
                Assert.Equal(testPair.address, new PrivKey(Base58Check.Decode(testPair.privKey).Payload).GetPubKey().GetEOSAddress().AddressString);
        }

        [Fact]
        public void FromStringTest()
        {
            foreach (var testPair in testData)
                Assert.Equal(testPair.address, new EOSAddress(testPair.address).AddressString);
        }
    }
}
