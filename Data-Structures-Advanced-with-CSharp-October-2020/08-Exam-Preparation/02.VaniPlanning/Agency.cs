namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        Dictionary<string, Invoice> bySerialNumber = new Dictionary<string, Invoice>();
        
        public void Create(Invoice invoice)
        {
            if (this.Contains(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            bySerialNumber[invoice.SerialNumber] = invoice;
        }

        public void ThrowInvoice(string number)
        {
            if (!this.Contains(number))
            {
                throw new ArgumentException();
            }

            bySerialNumber.Remove(number);
        }

        public void ThrowPayed()
        {
            var toRemove = bySerialNumber.Values
                .Where(x => x.Subtotal == 0)
                .Select(x => x.SerialNumber)
                .ToList();

            foreach (var number in toRemove)
            {
                bySerialNumber.Remove(number);
            }
        }

        public int Count()
        {
            return bySerialNumber.Count;
        }

        public bool Contains(string number)
        {
            return bySerialNumber.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            var toPay = bySerialNumber.Values
                .Where(x => x.DueDate == due)
                .ToList();

            if (toPay.Count == 0)
            {
                throw new ArgumentException();
            }

            foreach (var invoice in toPay)
            {
                invoice.Subtotal = 0;
            }
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            var inPeriod = bySerialNumber.Values
                .Where(x => x.IssueDate >= start && x.IssueDate <= end)
                .OrderBy(x => x.IssueDate)
                .ThenBy(x => x.DueDate)
                .ToList();

            if (inPeriod.Count == 0)
            {
                return Enumerable.Empty<Invoice>();
            }

            return inPeriod;
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var found = bySerialNumber.Values
                .Where(x => x.SerialNumber.Contains(serialNumber))
                .OrderByDescending(x => x.SerialNumber)
                .ToList();

            if (found.Count == 0)
            {
                throw new ArgumentException();
            }

            return found;
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            var toRemove = bySerialNumber.Values
                .Where(x => x.DueDate > start && x.DueDate < end)
                .Select(x => x.SerialNumber)
                .ToList();            

            if (toRemove.Count == 0)
            {
                throw new ArgumentException();
            }

            var removed = bySerialNumber.Values
                .Where(x => x.DueDate > start && x.DueDate < end)
                .ToList();

            foreach (var number in toRemove)
            {
                bySerialNumber.Remove(number);
            }

            return removed;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            var found = bySerialNumber.Values
                .Where(x => x.Department == department)
                .OrderByDescending(x => x.Subtotal)
                .ThenBy(x => x.IssueDate)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<Invoice>();
            }

            return found;
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            var found = bySerialNumber.Values
                .Where(x => x.CompanyName == company)
                .OrderByDescending(x => x.SerialNumber)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<Invoice>();
            }

            return found;
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            var toExtend = bySerialNumber.Values
                .Where(x => x.DueDate == dueDate)
                .Select(x => x.SerialNumber)
                .ToList();

            if (toExtend.Count == 0)
            {
                throw new ArgumentException();
            }

            foreach (var number in toExtend)
            {
                bySerialNumber[number].DueDate = bySerialNumber[number].DueDate.AddDays(days);
            }
        }
    }
}
