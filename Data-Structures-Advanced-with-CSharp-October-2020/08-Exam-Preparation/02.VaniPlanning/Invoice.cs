namespace _02.VaniPlanning
{
    using System;

    public class Invoice
    {
        public Invoice(string number, string company, double subtotal, Department dep, DateTime issueDate, DateTime dueDate)
        {
            this.SerialNumber = number;
            this.CompanyName = company;
            this.Subtotal = subtotal;
            this.Department = dep;
            this.IssueDate = issueDate;
            this.DueDate = dueDate;
        }
        public string SerialNumber { get; set; }

        public string CompanyName { get; set; }

        public double Subtotal { get; set; }

        public Department Department { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Invoice;
            if (other == null)
            {
                return false;
            }

            return this.SerialNumber == other.SerialNumber;
        }
    }
}
