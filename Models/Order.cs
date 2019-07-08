using System;

namespace coreangular.api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        // completed 안될수도있으니까.
        public DateTime? Completed { get; set; }
    }

}