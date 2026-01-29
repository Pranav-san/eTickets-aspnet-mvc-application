using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _Context;

        public ActorsService(AppDbContext context)
        {
            _Context = context;
            
        }


        public void AddActor(Actor actor)
        {
            _Context.Actors.Add(actor);
            _Context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _Context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _Context.Actors.Remove(result);
            await _Context.SaveChangesAsync();

        }

        public async Task<Actor> GetById(int id)
        {
            var result = await _Context.Actors.FirstOrDefaultAsync(n=>n.Id == id);
            return result;
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            var result = await _Context.Actors.ToListAsync();

            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _Context.Update(newActor);
            await _Context.SaveChangesAsync();
            return newActor;
        }

        
    }
}
