using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingBetterMessages
{
    public class BetterMessages
    {
        public static void WriteLogMessages()
        {
            Person customer = new Person(){Id = 1, LastName = "Graber", FirstName = "Johnny"};

            Order order = new Order { Customer = customer };


            // Bad message pattern:
            Log.Information("{0} ordered {1}", customer, order);


            // Message with named elements
            Log.Information("{customer} ordered {order}", customer, order);


            // Whole objects with @
            Log.Information("{@customer} ordered {@order}", customer, order);


            // Short but meaningful
            Log.Information("{customer} ordered {orderId}", customer, order.Id);
        }

    }

    #region Helper classes

    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1} {2}", Id, LastName, FirstName);
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public Person Customer { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }

    #endregion
}
