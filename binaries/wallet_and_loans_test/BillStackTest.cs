namespace wallet_and_loans_test
{
    public class BillStackTest
    {
        BillStack bill1;

        [SetUp]
        public void Setup()
        {
            bill1 = new BillStack("Test", 4, 12.00f);
        }

        [Test]
        public void TestBillSinglePrice()
        {
            float expected = 12.00f / 4;
            Assert.AreEqual(expected, bill1.SinglePrice);
        }

        [Test]
        public void TestSettingSinglePriceNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => bill1.SinglePrice = 100);
        }
    }
}