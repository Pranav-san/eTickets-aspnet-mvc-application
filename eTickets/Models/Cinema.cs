using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = " Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string name {  get; set; }

        [Display(Name = " Cinema Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string description { get; set; }

        //RelationShips
        public List<Movie> movies { get; set; }
    }
}
