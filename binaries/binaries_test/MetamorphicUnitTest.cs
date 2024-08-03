using binaries_cal.Calculations;

namespace binaries_test
{
    public class MetamorphicUnitTest
    {
        BinaryToIntCal bin_int_inversion;
        BinaryToIntCal bin_int_mirror;
        BinaryToIntCal bin_int_top_0;
        string inversion_expected = "35";
        string mirror_expected = "231";
        string top_0_expected = "10";

        [SetUp]
        public void Setup()
        {
            bin_int_inversion = new BinaryToIntCal("100011");
            bin_int_mirror = new BinaryToIntCal("11100111");
            bin_int_top_0 = new BinaryToIntCal("1010");
        }

        [Test]
        public void BitInversionTest()
        {
            string inverted_input = "011100"; // inverted from "100011"
            BinaryToIntCal bin_int_test = new BinaryToIntCal(inverted_input);
            string test_expected = "28";

            Assert.Multiple(() =>
            {
                Assert.AreEqual(inversion_expected, bin_int_inversion.Result);
                Assert.AreEqual(test_expected, bin_int_test.Result);
            });
        }

        [Test]
        public void MirrorBitsTest()
        {
            string mirrored_input = "11100111";   // mirrored from "11100111", very similar
            BinaryToIntCal bin_int_test = new BinaryToIntCal(mirrored_input);
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(mirror_expected, bin_int_mirror.Result);
                Assert.AreEqual(bin_int_mirror.Result, bin_int_test.Result);
            });
        }

        [Test]
        public void Add0sAtTopTest()
        {
            string padded_input = "00001010";   // add more 0s at the top of "1010"
            BinaryToIntCal bin_int_test = new BinaryToIntCal(padded_input);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(top_0_expected, bin_int_top_0.Result);
                Assert.AreEqual(bin_int_top_0.Result, bin_int_test.Result);
            });
        }
    }
}