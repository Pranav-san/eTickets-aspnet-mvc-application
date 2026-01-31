using eTickets.Data.Base;
using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage ="Movie Name is required")]
        public string name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }

        [Display(Name = "Movie price")]
        [Required(ErrorMessage = "price is required")]
        public double price { get; set; }

        [Display(Name = "Movie poster")]
        [Required(ErrorMessage = "poster is required")]
        public string ImageUrl { get; set; }

        [Display(Name = " Movie start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime startDate { get; set; }

        [Display(Name = "Movie end Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime endtDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie catagory is required")]
        public MovieCategory movieCategory {  get; set; }




        //Relationships
        [Display(Name = "Select a actors")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorsIDs { get; set; }


        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "cinema is required")]
        public int cinemaID { get; set; }


        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "producer is required")]
        public int producerID { get; set; }

        


    }
}
