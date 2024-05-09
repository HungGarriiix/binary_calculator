using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_and_loans.Logics
{
    public class Loan
    {
        public Loan(Bill bill)
        {
            BillToLoan = bill;
        }

        // get from db
        public Loan(Bill bill, List<Spending> spendings, bool paymentCompleted)
            : this(bill)
        {
            Spendings = spendings;
            PaymentCompleted = paymentCompleted;
        }

        public Bill BillToLoan { get; private set; } = null;
        public List<Spending> Spendings { get; private set; } = new List<Spending>();
        public bool PaymentCompleted { get; private set; } = false;

        public void AddSpending(Spending spending)
        {
            if (Spendings.FirstOrDefault(s => s.Loaned == spending.Loaned) != null) // loaned person exists
                throw new Exception($"{spending.Loaned.Name} is already exists.");

            Spendings.Add(spending);
        }

        public Spending GetSpending(Person person)
        {
            Spending spending = Spendings.FirstOrDefault(s => s.Loaned == person);
            if (spending == null)
                throw new Exception($"Cannot find the details about {person.Name}'s loan.");

            return spending;
        }

        public void DeleteSpending(Person person)
        {
            Spendings.Remove(GetSpending(person));
        }

        public void AddItemToLoaned(Spending spending, LoanStack item)
        {
            if (CheckItemAvailabilityInLoans(item))
                spending.GetItem(item.Name).Quantity += item.Quantity;
        }

        private bool CheckItemAvailabilityInLoans(LoanStack item)
        {
            int total = 0; // get from Bill
            int loaned = GetTotalLoanedItems(item.Name);
            int addition = item.Quantity;   // if the user is going to add items to loaned

            if (total >= loaned)
                throw new Exception("The item is already full.");
            if (total > loaned + addition)
                throw new Exception("Cannot add more items.");

            return true;
        }

        private int GetTotalLoanedItems(string itemName)
        {
            return Spendings.Sum(x => x.GetItem(itemName).Quantity);
        }

        public void MarkLoanFilled()
        {
            if (PaymentCompleted)
                throw new Exception("Loan has been fulfilled already!");

            PaymentCompleted = true;
        }

/*        public void UpdateSpending()
        {

        }*/
    }
}
