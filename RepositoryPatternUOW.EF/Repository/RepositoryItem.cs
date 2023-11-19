using Microsoft.EntityFrameworkCore;
using RepositoryPatternUOW.Core.Consts;
using RepositoryPatternUOW.Core.Repositors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternUOW.EF.Repository
{
    public class RepositoryItem<T> : IBaseRepository<T> where T : class
    {
        public readonly ApplicationContext _context;
        public RepositoryItem(ApplicationContext context)
        {
           _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity); 
           return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
           _context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
           await _context.Set<T>().AddRangeAsync(entities);
           return entities;
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public  void AttachRange(IEnumerable<T> entities)
        {
             _context.Set<T>().AttachRange(entities);
            
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
           return _context.Set<T>().Where(criteria).Count();
        }

        public async Task<int> CountAsync()
        {
            
            return await _context.Set<T>().CountAsync();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Where(criteria).CountAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            var query = _context.Set<T>();
            if (includes is not null)
            {
                foreach (var include in includes)
                    query.Include(include);
            }
            return query.FirstOrDefault(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            var query = _context.Set<T>().Where(criteria);
            if (includes is not null)
            {
                foreach (var include in includes)
                    query.Include(include);
            }
            return query.ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            var query = _context.Set<T>().Where(criteria);

            if(take > 0)
                query.Take(take);
            if(skip > 0)  
                query.Skip(skip);
            return query.ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            var query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query.Take((int)take);
            if (skip.HasValue)
                query.Skip((int)skip);
            if (orderBy is not null)
            {
                if (orderByDirection == OrderBy.Ascending)
                query.OrderBy(orderBy);
                else
                query.OrderByDescending(orderBy);
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {

            var query = _context.Set<T>().Where(criteria);
            if (includes is not null)
            {
                foreach (var include in includes)
                    query.Include(include);
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take)
        {
            var query = _context.Set<T>().Where(criteria);

            if (take > 0)
                query.Take(take);
            if (skip > 0)
                query.Skip(skip);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            var query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query.Take((int)take);
            if (skip.HasValue)
                query.Skip((int)skip);
            if (orderBy is not null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query.OrderBy(orderBy);
                else
                    query.OrderByDescending(orderBy);
            }
            return await query.ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            var query = _context.Set<T>();
            if (includes is not null)
            {
                foreach (var include in includes)
                    query.Include(include);
            }
            return await query.FirstOrDefaultAsync(criteria);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
          return await  _context.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
           _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
