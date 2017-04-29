using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    static class Program
    {

        const double HIGH_INVOICE_AMOUNT = 100.0;

        public static InvoiceStatus PAID_INVOICE => InvoiceStatuses.PAID;

        static void Main(string[] args)
        {

            //What I once did :( 
            List<Invoice> invoicesByForEachAndIf = new List<Invoice>();
            foreach (var invoice in GetInvoices())
            {
                if (invoice.InvoiceAmount >= HIGH_INVOICE_AMOUNT && invoice.InvoiceStatus.Code == PAID_INVOICE.Code)
                {
                    invoicesByForEachAndIf.Add(invoice); 

                }
            }
            PrintOutInvoiceList(invoicesByForEachAndIf);

            //extracting out the select condtion, a little nicer
            List<Invoice> invoicesByForEachAndMethod = new List<Invoice>(); 
            foreach (var invoice in GetInvoices())
            {
                if (HighPaidInvoice(invoice.InvoiceAmount, invoice.InvoiceStatus.Code))
                {
                    invoicesByForEachAndMethod.Add(invoice); 
                }
            }
            PrintOutInvoiceList(invoicesByForEachAndMethod); 


            //hey what's this linq thing.  '=>' equals goes to.. it's lamb something... lambda 
            var invoicesByLinqAndAnonMethod = GetInvoices()
                                             .Where(i => i.InvoiceAmount >= HIGH_INVOICE_AMOUNT && i.InvoiceStatus.Code == PAID_INVOICE.Code)
                                             .OrderBy(i => i.InvoiceAmount);
            PrintOutInvoiceList(invoicesByLinqAndAnonMethod);

            //used the high paid method 
            var invoicesByLinqAndMethod = GetInvoices()
                                         .Where(i => HighPaidInvoice(i.InvoiceAmount, i.InvoiceStatus.Code))
                                         .OrderBy( i => i.InvoiceAmount);
            PrintOutInvoiceList(invoicesByLinqAndMethod);

            //this is fun too but is it nicer? 
            var invoicesByCSQL =
                from invoice in GetInvoices()
                where invoice.InvoiceAmount >= HIGH_INVOICE_AMOUNT 
                && invoice.InvoiceStatus.Code == PAID_INVOICE.Code
                orderby invoice.InvoiceAmount
                select invoice;    
            PrintOutInvoiceList(invoicesByCSQL);

            //how about this?
            var invoicesByCSQLMethod =
            from invoice in GetInvoices()
            where HighPaidInvoice(invoice.InvoiceAmount, invoice.InvoiceStatus.Code)
            orderby invoice.InvoiceAmount
            select invoice;

            PrintOutInvoiceList(invoicesByCSQLMethod);

            //extracted the linq out of the main code
            PrintOutInvoiceList(GetHighPayingInvoicesEnum(GetInvoices(), HighPaidInvoice));
            
            // made to be functional 
            PrintOutInvoiceList(GetInvoices()
                               .GetHighPayingInvoices(HighPaidInvoice)
                               .OrderBy(i => i.InvoiceAmount)
                               );

            Console.ReadLine();
        }

        static bool HighPaidInvoice(double amount, string invoiceStatusCode)
        {
            if (amount >= HIGH_INVOICE_AMOUNT && invoiceStatusCode == PAID_INVOICE.Code)
            {
                return true;
            }
            return false;
        }

        static IEnumerable<Invoice> GetHighPayingInvoices(this IEnumerable<Invoice> list, Func<double, string, bool> filter)
        {
            return list.Where(i => filter(i.InvoiceAmount, i.InvoiceStatus.Code));
        }
        static IOrderedEnumerable<Invoice> GetHighPayingInvoicesEnum(IEnumerable<Invoice> list, Func<double, string, bool> filter)
        {
            return list.Where(i => filter(i.InvoiceAmount, i.InvoiceStatus.Code)).OrderBy(i => i.InvoiceAmount); 
        }

        static void PrintOutInvoiceList(IEnumerable<Invoice> invoiceList)
        {
            WriteFunctionSeperator();
            foreach (var invoice in invoiceList)
            {
                Console.WriteLine("Invoice Number {0} for {1:C} ", invoice.InvoiceNumber, invoice.InvoiceAmount);
            }
        }

        static void WriteFunctionSeperator()
        {
            Console.WriteLine("---------------------------------------");
        }



        static List<Invoice> GetInvoices()
        {
            return new List<Invoice>() {
                new Invoice()
                {
                    Contact = new Contact("Andrew"),
                    InvoiceAmount = 2.00,
                    InvoiceNumber = "INV-1",
                    InvoiceStatus = InvoiceStatuses.DRAFT
                },
                new Invoice()
                {
                    Contact = new Contact("Jack"),
                    InvoiceAmount = 32.00,
                    InvoiceNumber = "INV-2",
                    InvoiceStatus = InvoiceStatuses.INPROGESS
                },
                new Invoice()
                {
                    Contact = new Contact("Ben"),
                    InvoiceAmount = 25.00,
                    InvoiceNumber = "INV-3",
                    InvoiceStatus = InvoiceStatuses.PAID
                },
                new Invoice()
                {
                    Contact = new Contact("James"),
                    InvoiceAmount = 564.00,
                    InvoiceNumber = "INV-4",
                    InvoiceStatus = InvoiceStatuses.INPROGESS
                },
                new Invoice()
                {
                    Contact = new Contact("Ben"),
                    InvoiceAmount = 456.00,
                    InvoiceNumber = "INV-5",
                    InvoiceStatus = InvoiceStatuses.INPROGESS
                },
                new Invoice()
                {
                    Contact = new Contact("Jack"),
                    InvoiceAmount = 23.00,
                    InvoiceNumber = "INV-6",
                    InvoiceStatus = InvoiceStatuses.DRAFT
                },
                new Invoice()
                {
                    Contact = new Contact("Daniel"),
                    InvoiceAmount = 324.00,
                    InvoiceNumber = "INV-7",
                    InvoiceStatus = InvoiceStatuses.PAID
                },
                new Invoice()
                {
                    Contact = new Contact("John"),
                    InvoiceAmount = 55.00,
                    InvoiceNumber = "INV-8",
                    InvoiceStatus = InvoiceStatuses.DRAFT
                },
                new Invoice()
                {
                    Contact = new Contact("Harry"),
                    InvoiceAmount = 453.00,
                    InvoiceNumber = "INV-9",
                    InvoiceStatus = InvoiceStatuses.PAID
                },
                new Invoice()
                {
                    Contact = new Contact("Sally"),
                    InvoiceAmount = 67.00,
                    InvoiceNumber = "INV-10",
                    InvoiceStatus = InvoiceStatuses.INPROGESS
                },
                new Invoice()
                {
                    Contact = new Contact("Ben"),
                    InvoiceAmount = 543.00,
                    InvoiceNumber = "INV-11",
                    InvoiceStatus = InvoiceStatuses.DRAFT
                },
                new Invoice()
                {
                    Contact = new Contact("Sally"),
                    InvoiceAmount = 33.00,
                    InvoiceNumber = "INV-12",
                    InvoiceStatus = InvoiceStatuses.INPROGESS
                },
                new Invoice()
                {
                    Contact = new Contact("John"),
                    InvoiceAmount = 345.00,
                    InvoiceNumber = "INV-13",
                    InvoiceStatus = InvoiceStatuses.DRAFT
                },
                new Invoice()
                {
                    Contact = new Contact("Jack"),
                    InvoiceAmount = 135.00,
                    InvoiceNumber = "INV-14",
                    InvoiceStatus = InvoiceStatuses.PAID
                },
                new Invoice()
                {
                    Contact = new Contact("Richard"),
                    InvoiceAmount = 123.00,
                    InvoiceNumber = "INV-15",
                    InvoiceStatus = InvoiceStatuses.DRAFT
                }
            };
        }
    }
}
