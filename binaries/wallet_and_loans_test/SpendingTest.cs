using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace wallet_and_loans_test
{
    public class SpendingTest
    {
        Person person1;
        Spending spending1;
        LoanStack cart;
        LoanStack shoes;
        LoanStack chocolate;

        [SetUp]
        public void SetUp()
        {
            person1 = new Person(1, "Test");
            spending1 = new Spending(person1, "Test loaned.");
            cart = new LoanStack("Cart", 13, 15.00f);
            shoes = new LoanStack("Shoes", 1, 100f);
            chocolate = new LoanStack("Chocolate", 10, 1f);
        }

        [Test]
        public void TestSpendingDefaultConstructor()
        {
            Assert.Multiple(() =>
            {
                Assert.That(spending1.Loaned, Is.SameAs(person1));
                Assert.That(spending1.Description, Is.EqualTo("Test loaned."));
            });
        }

        [TestCaseSource("AddItemTestCase")] // might optimise this to accept more LoanStack objects
        public void TestAddItem((LoanStack item, string itemName) test)
        {
            spending1.AddItem(test.item);

            Assert.That(spending1.GetItem(test.itemName).Name, Is.EqualTo(test.itemName));
        }

        [Test]
        public void TestAddItemWhenPaid()
        {
            spending1.SealSpending();

            Assert.Throws<Exception>(() => spending1.AddItem(shoes), "The spending has been sealed.");
        }

        [Test]
        public void TestAddSameItem()
        {
            spending1.AddItem(shoes);
            spending1.AddItem(shoes);

            Assert.Multiple(() =>
            {
                Assert.That(spending1.GetItem("Shoes").Quantity, Is.EqualTo(2));
                Assert.That(spending1.NumberOfItems, Is.EqualTo(1));
            });
        }

        [TestCaseSource("AddItemTestCase")]
        public void TestGetItem((LoanStack item, string itemName) test)
        {
            spending1.ItemList.Add(test.item);

            Assert.That(spending1.GetItem(test.itemName), Is.SameAs(test.item));
        }

        [Test]
        public void TestGetNonExistedItem()
        {
            Assert.Throws<Exception>(() => spending1.GetItem("Cart"), "Cannot find item with name 'Cart' ...");
        }

        [Test]
        public void TestGetItemWhenPaid()
        {
            spending1.SealSpending();

            Assert.Throws<Exception>(() => spending1.GetItem("Random item"), "The spending has been sealed.");
        }

        [Test]
        public void TestChangeItemInfo()
        {
            spending1.AddItem(shoes);
            LoanStack test = new LoanStack("Test change", 15, 15f);
            spending1.ChangeItemInfo(shoes.Name, test);

            Assert.Multiple(() =>
            {
                Assert.That(spending1.GetItem("Test change").Name, Is.EqualTo("Test change"));
                Assert.That(spending1.GetItem("Test change").Quantity, Is.EqualTo(15));
                Assert.That(spending1.GetItem("Test change").SinglePrice, Is.EqualTo(15f));
                Assert.That(spending1.GetItem("Test change"), Is.Not.SameAs(test));
            });
        }

        [Test]
        public void TestChangeNonExistedItem()
        {
            Assert.Throws<Exception>(() => spending1.ChangeItemInfo("Non existed", new LoanStack("Random item", 1, 1f)), "Cannot find item with name 'Non existed'...");
        }

        [Test]
        public void TestChangeItemInfoWhenSealed()
        {
            spending1.SealSpending();

            Assert.Throws<Exception>(() => spending1.ChangeItemInfo("Random item", shoes), "The spending has been sealed.");
        }

        [Test]
        public void TestRemoveItem()
        {
            spending1.AddItem(shoes);
            spending1.AddItem(cart);
            spending1.AddItem(chocolate);
            spending1.RemoveItem(shoes.Name);
            spending1.RemoveItem(cart.Name);
            spending1.RemoveItem(chocolate.Name);

            Assert.Multiple(() =>
            {
                Assert.Throws<Exception>(() => spending1.GetItem(shoes.Name));
                Assert.Throws<Exception>(() => spending1.GetItem(cart.Name));
                Assert.Throws<Exception>(() => spending1.GetItem(chocolate.Name));
            });
        }

        [TestCase("Testing")]
        [TestCase("Shoes")]
        [TestCase("Cart")]
        [TestCase("Chocolate")]
        public void TestRemoveNonExistedItem(string item)
        {
            Assert.Throws<Exception>(() => spending1.RemoveItem(item), $"Cannot find item with name '{item}'...");
        }

        [Test]
        public void TestRemoveASetOfQuantity()
        {
            spending1.AddItem(chocolate);
            spending1.AddItem(cart);
            spending1.RemoveItem(chocolate.Name, 4);

            Assert.Multiple(() =>
            {
                Assert.That(chocolate.Quantity, Is.EqualTo(6));
                Assert.That(cart.Quantity, Is.EqualTo(13));
            });
        }

        [Test]
        public void TestRemoveEntireQuantity()
        {
            spending1.AddItem(chocolate);
            spending1.RemoveItem(chocolate.Name, 10);

            Assert.Throws<Exception>(() => spending1.GetItem("Chocolate"), "Cannot find item with name 'Chocolate'...");
        }

        [Test]
        public void TestRemoveItemWhenSealed()
        {
            spending1.SealSpending();

            Assert.Throws<Exception>(() => spending1.RemoveItem("Random item"), "The spending has been sealed.");
        }

        [Test]
        public void TestSealSpending()
        {
            spending1.SealSpending();

            Assert.That(spending1.IsPaid, Is.True);
        }

        [TestCaseSource("AddItemTestCasePrice")]    // might optimise this to accept more LoanStack objects
        public void TestNumberOfItemsWhenAdd1((LoanStack item, int quantity) i)
        {
            spending1.AddItem(i.item);

            Assert.That(spending1.NumberOfItems, Is.EqualTo(1));
        }

        [Test]
        public void TestNumberOfItemsWhenAddAll()
        {
            spending1.AddItem(shoes);
            spending1.AddItem(cart);
            spending1.AddItem(chocolate);

            Assert.That(spending1.NumberOfItems, Is.EqualTo(3));
        }

        [Test]
        public void TestNumberOfItemsWhenEmpty()
        {
            Assert.That(spending1.NumberOfItems, Is.EqualTo(0));
        }

        [TestCaseSource("AddItemTestCasePrice")]    // might optimise this to accept more LoanStack objects
        public void TestNumberOfQuantitiesWhenAddOne((LoanStack item, int quantity) i)
        {
            spending1.AddItem(i.item);

            Assert.That(spending1.NumberOfQuantities, Is.EqualTo(i.quantity));
        }

        [Test]
        public void TestNumberOfQuantitiesWhenAddAll()
        {
            spending1.AddItem(shoes);
            spending1.AddItem(cart);
            spending1.AddItem(chocolate);

            Assert.That(spending1.NumberOfQuantities, Is.EqualTo(24));
        }

        [Test]
        public void TestNumberOfQuantitiesWhenEmpty()
        {
            Assert.That(spending1.NumberOfQuantities, Is.EqualTo(0));
        }

        private static IEnumerable<(LoanStack, string)> AddItemTestCase()
        {
            yield return (new LoanStack("Cart", 13, 15.00f), "Cart");
            yield return (new LoanStack("Shoes", 1, 100f), "Shoes");
            yield return (new LoanStack("Chocolate", 10, 1f), "Chocolate");
        }

        private static IEnumerable<(LoanStack, int)> AddItemTestCasePrice()
        {
            yield return (new LoanStack("Cart", 13, 15.00f), 13);
            yield return (new LoanStack("Shoes", 1, 100f), 1);
            yield return (new LoanStack("Chocolate", 10, 1f), 10);
        }

        /*private static IEnumerable<(LoanStack, string)> AddItemTestCase2()
        {
            yield return (new LoanStack("Cart", 13, 15.00f), "Cart");
            yield return (new LoanStack("Chocolate", 10, 1f), "Chocolate");
        }

        private static IEnumerable<(LoanStack, string)> AddItemTestCase3()
        {
            yield return (new LoanStack("Shoes", 1, 100f), "Shoes");
            yield return (new LoanStack("Chocolate", 10, 1f), "Chocolate");
        }

        private static IEnumerable<(LoanStack, string)> AddItemTestCase4()
        {
            yield return (new LoanStack("Cart", 13, 15.00f), "Cart");
            yield return (new LoanStack("Shoes", 1, 100f), "Shoes");
        }

        private static IEnumerable<(LoanStack, string)> AddItemTestCase5()
        {
            yield return (new LoanStack("Cart", 13, 15.00f), "Cart");
        }

        private static IEnumerable<(LoanStack, string)> AddItemTestCase6()
        {
            yield return (new LoanStack("Shoes", 1, 100f), "Shoes");
        }

        private static IEnumerable<(LoanStack, string)> AddItemTestCase7()
        {
            yield return (new LoanStack("Chocolate", 10, 1f), "Chocolate");
        }*/
    }
}
