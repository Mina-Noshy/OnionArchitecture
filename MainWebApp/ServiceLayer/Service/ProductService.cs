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
    public class ProductService : IService<Product>
    {
        private readonly IRepository<Product> _ProductRepo;
        public ProductService(IRepository<Product> ProductRepo)
        {
            _ProductRepo = ProductRepo;
        }
        public async Task<bool> Delete(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    return await _ProductRepo.Delete(entity);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Product?> Get(int Id)
        {
            try
            {
                var obj = await _ProductRepo.Get(Id);
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

        public async Task<IEnumerable<Product>?> GetAll()
        {
            try
            {
                var obj = await _ProductRepo.GetAll();
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

        public async Task<bool> Insert(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    return await _ProductRepo.Insert(entity);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> Update(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    return await _ProductRepo.Update(entity);
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
                return await _ProductRepo.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
