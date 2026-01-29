using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string profilePicUrl { get; set; }

        [Display(Name = "Full Name")]
        public string Fullname { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }


        //RelationShips
        public List<Movie> movies { get; set; }
    }
}
