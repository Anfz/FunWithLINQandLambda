namespace Linq
{
    public class InvoiceStatus
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class InvoiceStatuses
    {
        public static readonly InvoiceStatus DRAFT = new InvoiceStatus() { Code = "DRAFT", Description =  "Draft" };
        public static readonly InvoiceStatus INPROGESS = new InvoiceStatus() { Code = "INPROGRESS", Description = "In Progress" };
        public static readonly InvoiceStatus PAID = new InvoiceStatus() { Code = "PAID", Description = "Paid" };
    }
}