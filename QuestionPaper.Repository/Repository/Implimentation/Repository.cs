using Microsoft.EntityFrameworkCore;
using QuestionPaper.Data.Entities.DataContext;
using QuestionPaper.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionPaper.Repository.Repository.Implimentation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly QuestionDbcontext context;

        public Repository(QuestionDbcontext _dbContext)
        {
            context = _dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetByIdSubQuestion(int id)
        {
          return await context.Set<T>().Where(s=>s.Equals(id)).ToListAsync();
        }
        public async Task<T> GetById(int id)
        {

            return await context.Set<T>().FindAsync(id);
        }
        public void Add(T data)
        {
            context.Set<T>().AddAsync(data);
            context.SaveChanges();
        }

        public void Update(T data)
        {
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = context.Set<T>().Find(id);
            context.Set<T>().Remove(data);
            context.SaveChanges();
        }
    }
}
