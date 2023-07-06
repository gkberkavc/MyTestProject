using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class IEntityRepositoryBase<Tentity, Tcontext> : IEntityRepository<Tentity> where Tentity : class, IEntity, new()
        where Tcontext : DbContext, new()
    {
        public async Task Add(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var addedEntry = context.Entry<Tentity>(entity);
                addedEntry.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var deletedEntry = context.Remove<Tentity>(entity);
                deletedEntry.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
        public async Task<Tentity> Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var context = new Tcontext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }
        public async Task<List<Tentity>> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var context = new Tcontext())
            {
                return filter == null ? context.Set<Tentity>().ToList() : context.Set<Tentity>().Where(filter).ToList();
            }
        }
        public async Task Update(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var updateEntry = context.Update<Tentity>(entity);
                updateEntry.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
