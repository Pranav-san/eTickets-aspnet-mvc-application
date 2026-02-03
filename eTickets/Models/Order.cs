using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        //Relationship
        public List<OrderItem> OrderItems { get; set; }
    }
}
