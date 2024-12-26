using BLL.Services.Abstracts;
using DAL.Repositories.Abstracts;
using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class ServiceManager<T> : IServiceManager<T> where T : BaseEntity
    {
        
        
        private readonly IRepository<T> _repository;

        public ServiceManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(T item)
        {
            if (item != null)
            {
                await _repository.CreateAsync(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public async Task CreateRangeAsync(List<T> item)
        {
            if (item != null)
            {
                await _repository.CreateRangeAsync(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public async Task DeleteAsync(T item)
        {
            if (item != null)
            {
                await _repository.DeleteAsync(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public async Task DeleteRangeAsync(List<T> item)
        {
            if (item != null)
            {
                await _repository.DeleteRangeAsync(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public void Destroy(T item)
        {
            _repository.Destroy(item);
        }

        public void DestroyRange(List<T> item)
        {
            if (item != null)
            {
                _repository.DestroyRange(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public IEnumerable<T> GetActives()
        {
            return _repository.GetActives().ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetPassives()
        {
            return _repository.GetPassives().ToList();
        }

        public async Task UpdateAsync(T item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task UpdateRangeAsync(List<T> item)
        {
            await _repository.UpdateRangeAsync(item);
        }
    }
}
