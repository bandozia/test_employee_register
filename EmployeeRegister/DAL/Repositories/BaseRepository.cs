using EmployeeRegister.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly CoreContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(CoreContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await DbSet.SingleOrDefaultAsync(i => i.Id == id);
        }

        public virtual async Task<ICollection<T>> GetByIds(int[] ids)
        {
            return await DbSet.Where(i => ids.Contains(i.Id)).ToListAsync();
        }

        public virtual async Task<T> Insert(T item)
        {
            DbSet.Add(item);
            await Context.SaveChangesAsync();
            return item;
        }                
    }
}
