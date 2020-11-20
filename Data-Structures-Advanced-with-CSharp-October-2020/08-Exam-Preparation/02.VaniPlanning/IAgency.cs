namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;

    public interface IAgency
    {
        void Create(Invoice invoice);

        void ThrowInvoice(string number);

        void ThrowPayed();

        int Count();

        bool Contains(string number);

        void PayInvoice(DateTime due);

        IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end);

        IEnumerable<Invoice> SearchBySerialNumber(string serialNumber);

        IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end);

        IEnumerable<Invoice> GetAllFromDepartment(Department department);

        IEnumerable<Invoice> GetAllByCompany(string company);

        void ExtendDeadline(DateTime dueDate, int days);

    }
}
