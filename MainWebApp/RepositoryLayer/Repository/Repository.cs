using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region property
        private readonly AppDbContext _db;
        private DbSet<T> entities;
        #endregion

        #region Constructor
        public Repository(AppDbContext db)
        {
            _db = db;
            entities = _db.Set<T>();
        }
        #endregion

        public async Task<bool> Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Remove(entity);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T?> Get(int Id)
        {
            try
            {
                return await entities.SingleOrDefaultAsync(c => c.Id == Id);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<IEnumerable<T>?> GetAll()
        {
            try
            {
                return await entities.ToListAsync();
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<bool> Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                await entities.AddAsync(entity);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> SaveChanges()
        {
            try
            {
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {

                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Update(entity);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
