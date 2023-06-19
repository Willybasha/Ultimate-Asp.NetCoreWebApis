using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainLayer4.Context;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer4
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext repositoryContext)
        =>_context= repositoryContext;

        public IQueryable<T> FindAll(bool trackChanges) =>!trackChanges ? _context.Set<T>().AsNoTracking()
            : _context.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
        !trackChanges ?
        _context.Set<T>()
        .Where(expression)
        .AsNoTracking() :
         _context.Set<T>()
        .Where(expression);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void CreateMany(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
