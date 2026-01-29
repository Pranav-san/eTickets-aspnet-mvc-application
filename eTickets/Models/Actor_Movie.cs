namespace eTickets.Models
{
    public class Actor_Movie
    {
        public int movieID { get; set; }
        public Movie movie { get; set; }

        public int actorID { get; set; }
        public Actor actor { get; set; }
    }
}
