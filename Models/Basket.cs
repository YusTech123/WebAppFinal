using System.Collections.Generic;
namespace WebAppFinal.Models
{
    public class Basket
    {
        public int CustomerId { get; set; }
        public int BasketId { get; set; }
        public int OrderId { get; set; } // Foreign key to Order
        public int ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; }

    }
}
