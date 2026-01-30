using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasService: EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemasService(AppDbContext context): base(context)
        {

        }
    }
}
