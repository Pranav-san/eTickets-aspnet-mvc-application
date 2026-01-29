using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string ImageUrl { get; set; }

        public DateTime startDate { get; set; }
        public DateTime endtDate { get; set; }

        public MovieCategory movieCategory {  get; set; }




        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cinema
        public int cinemaID { get; set; }

        [ForeignKey ("cinemaID")]
        public Cinema cinema { get; set; }

        //Producer
        public int producerID { get; set; }

        [ForeignKey("producerID")]
        public Producer producer { get; set; }


    }
}
