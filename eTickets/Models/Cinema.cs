using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema: IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = " Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string Name {  get; set; }

        [Display(Name = " Cinema Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }

        //RelationShips
        public List<Movie> Movies { get; set; }
    }
}
