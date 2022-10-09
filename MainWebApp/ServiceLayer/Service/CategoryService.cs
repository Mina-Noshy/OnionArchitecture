using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<Category> _CatRepo;
        public CategoryService(IRepository<Category> CatRepo)
        {
            _CatRepo = CatRepo;
        }
        public async Task<bool> Delete(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    return await _CatRepo.Delete(entity);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Category?> Get(int Id)
        {
            try
            {
                var obj = await _CatRepo.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                return default;

            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<IEnumerable<Category>?> GetAll()
        {
            try
            {
                var obj = await _CatRepo.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<bool> Insert(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    return await _CatRepo.Insert(entity);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> Update(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    return await _CatRepo.Update(entity);
                }
                return false;
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
                return await _CatRepo.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
