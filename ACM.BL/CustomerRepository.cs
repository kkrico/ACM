using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public Customer Find(List<Customer> customerList, int customerId)
        {
            Customer foundCustomer = null;

            //foreach (var customer in customerList)
            //{
            //    if (customer.CustomerId == customerId)
            //    {
            //        customerFound = customer;
            //        break;
            //    }
            //}

            //var query = from customer in customerList
            //                    where customer.CustomerId == customerId
            //                    select customer;
            //foundCustomer = query.First();

            foundCustomer = customerList.FirstOrDefault(c => c.CustomerId == customerId);

            //foundCustomer = customerList.FirstOrDefault(c =>
            //{
            //    Debug.WriteLine(c.LastName);
            //    return c.CustomerId == customerId;
            //});

            //foundCustomer = customerList.Where(c => c.CustomerId == customerId)
            //                            .Skip(1)
            //                            .FirstOrDefault();

            return foundCustomer;
        }

        public List<Customer> Retrieve()
        {
            InvoiceRepository invoiceRepository = new InvoiceRepository();

            List<Customer> custList = new List<Customer>
                    {new Customer()
                          { CustomerId = 1,
                            FirstName="Frodo",
                            LastName = "Baggins",
                            EmailAddress = "fb@hob.me",
                            CustomerTypeId=1,
                            InvoiceList=invoiceRepository.Retrieve(1)},
                    new Customer()
                          { CustomerId = 2,
                            FirstName="Bilbo",
                            LastName = "Baggins",
                            EmailAddress = "bb@hob.me",
                            CustomerTypeId=null,
                            InvoiceList=invoiceRepository.Retrieve(2)},
                    new Customer()
                          { CustomerId = 3,
                            FirstName="Samwise",
                            LastName = "Gamgee",
                            EmailAddress = "sg@hob.me",
                            CustomerTypeId=4,
                            InvoiceList=invoiceRepository.Retrieve(3)},
                    new Customer()
                          { CustomerId = 4,
                            FirstName="Rosie",
                            LastName = "Cotton",
                            EmailAddress = "rc@hob.me",
                            CustomerTypeId = 2,
                            InvoiceList = invoiceRepository.Retrieve(4)}};
            return custList;
        }

        public IEnumerable<string> GetNames(List<Customer> customers)
        {
            var query = customers.Select(c => $"{c.LastName} , {c.FirstName}");

            return query;
        }


        public IEnumerable<Customer> GetOverdueCustomers(List<Customer> customers)
        {
            var query = customers.SelectMany(c => c.InvoiceList
            .Where(i => (i.IsPaid ?? false) == false),
            (c, i) => c).Distinct();

            return query;
        }

        public dynamic GetNamesAndEmails(List<Customer> customers)
        {
            var query = customers.Select(c => new
            {
                Name = c.LastName + c.FirstName,
                c.EmailAddress,
            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " : " + item.EmailAddress);
            }

            return query;
        }


        public dynamic GetNamesAndTypeName(List<Customer> customers, List<CustomerType> customerTypes)
        {
            var query1 = customers.Join(customerTypes,
                c => c.CustomerTypeId,
                ct => ct.CustomerTypeId,
                (c, ct) => new
                {
                    Name = c.LastName + ", " + c.FirstName,
                    CustomerTypeName = ct.TypeName
                });

            var query2 = from customer in customers
                         join cType in customerTypes
                             on customer.CustomerTypeId equals cType.CustomerTypeId
                         select new
                         {
                             Name = customer.LastName + ", " + customer.FirstName,
                             CustomerTypeName = cType.TypeName
                         };

            foreach (var item in query1)
            {
                Console.WriteLine(item.Name + " : " + item.CustomerTypeName);
            }

            foreach (var item in query2)
            {
                Console.WriteLine(item.Name + " : " + item.CustomerTypeName);
            }

            return query1;
        }

        public IEnumerable<Customer> SortByName(List<Customer> customers)
        {
            return customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse(List<Customer> customers)
        {
            //return customers.OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName);

            return SortByName(customers).Reverse();
        }

        public IEnumerable<Customer> SortByType(List<Customer> customers)
        {
            return customers.OrderByDescending(c => c.CustomerTypeId.HasValue)
                            .ThenBy(c => c.CustomerTypeId);
        }

        public IEnumerable<Customer> RetrieveEmptyList()
        {
            return Enumerable.Repeat(new Customer(), Retrieve().Count);
        }
    }
}
