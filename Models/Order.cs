using System.Collections.Generic;
namespace WebAppFinal.Models

{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; } // Foreign key to Customer
        public int ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; } // Total amount for the order
    }
}
