using System;
using System.Linq;
using Xunit;
using NEOS.Key;
using NEOS.Extensions;

namespace NEOS.Tests.Encoding
{
    public class PrivKeyTests
    {
        private (string privKey, string uncompressedPubKey, string compressedPubKey)[] testData = new(string, string, string)[] {
            ("0x516e0360cf8eaea26b82d3171831bcd0c26afe6846b4c16def8d2f9fccf86b65",
            "0x04c0464dd5c887909e35515c9eb5ba5d9ea947575c04abf886406458b1596ce14eb06a0b09da3eece2bfde44f56d4e0b80e42d8ccb98c897c640aaf1e23ce03f03",
            "0x03c0464dd5c887909e35515c9eb5ba5d9ea947575c04abf886406458b1596ce14e"),
            ("0xf552071af06399d7315c23a6bc40133b591f8e2a522f52be93e22cb219c908c3",
            "0x0482e0833e92926de72411c53c9f3fce55304fce7a4bda4c3aef59b41ae7f39722504d985adce8850c20c97380b88d04f60af9fd5735850e233b8ac566895e45ef",
            "0x0382e0833e92926de72411c53c9f3fce55304fce7a4bda4c3aef59b41ae7f39722"),
            ("0x38e01dfebe107df83024991fe4add5063ed2173617df32a7747d1d87e486aae7",
            "0x049e80e314f17f803211af2b5c7fd5cb9807c3fa1f709c51b21541ecb12fa7349aa75035eda8aa50235ef8c8289caf261d0ad25a236d3c4e074c7f6f6834ebe97f",
            "0x039e80e314f17f803211af2b5c7fd5cb9807c3fa1f709c51b21541ecb12fa7349a")
        };

        [Fact]
        public void GetUncompressedPubKeyTest()
        {
            foreach (var testPair in testData)
                Assert.Equal(testPair.uncompressedPubKey.ToBytes(), new PrivKey(testPair.privKey.ToBytes()).GetPubKey(false).GetEncoded());
        }

        [Fact]
        public void GetCompressedPubKeyTest()
        {
            foreach (var testPair in testData)
                Assert.Equal(testPair.compressedPubKey.ToBytes(), new PrivKey(testPair.privKey.ToBytes()).GetPubKey(true).GetEncoded());
        }
    }
}
