using DAL.Context;
using DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ProjectContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }




        public async Task CreateAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(List<T> item)
        {
            if (item == null || item.Count == 0)
                throw new ArgumentException("Item list cannot be null or empty.", nameof(item));

            await _dbSet.AddRangeAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<T> item)
        {
            if (item == null || item.Count == 0)
                throw new ArgumentException("Item list cannot be null or empty.", nameof(item));

            _dbSet.RemoveRange(item);
            await _context.SaveChangesAsync();
        }

        public void Destroy(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            item.IsActive = false; // BaseEntity içinde IsActive varsa

            _dbSet.Update(item);
            _context.SaveChanges();
        }

        public void DestroyRange(List<T> item)
        {
            if (item == null || item.Count == 0)
                throw new ArgumentException("Item list cannot be null or empty.", nameof(item));
            foreach (var i in item)
            {
                i.IsActive = false; // BaseEntity içinde IsActive varsa
            }

            _dbSet.UpdateRange(item);
            _context.SaveChanges();
        }

        public IQueryable<T> GetActives()
        {
            return _dbSet.Where(x => x.IsActive); // BaseEntity içinde IsActive varsa
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;

        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetPassives()
        {
            return _dbSet.Where(x => !x.IsActive); // BaseEntity içinde IsActive varsa
        }

        public async Task UpdateAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<T> item)
        {
            if (item == null || item.Count == 0)
                throw new ArgumentException("Item list cannot be null or empty.", nameof(item));

            _dbSet.UpdateRange(item);
            await _context.SaveChangesAsync();
        }
    }
}
