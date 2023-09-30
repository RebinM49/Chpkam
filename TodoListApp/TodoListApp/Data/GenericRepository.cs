using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> _table;
        TodoListDbContext _dbcontext;
        public GenericRepository()
        {
            _dbcontext = new TodoListDbContext();
            _table = _dbcontext.Set<T>();
        }
        public bool Add(T item)
        {
                _table.Add(item);
                _dbcontext.SaveChanges();
                return true;
        }
        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _table;
            var properties = typeof(T).GetProperties()
               .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(List<>)
                        && p.PropertyType.GetGenericArguments()[0] == typeof(ToDoTask));


            foreach (var property in properties)
            {
                query = query.Include(property.Name);
            }
            return query.ToList();
        }

        public bool Delete(int id)
        {
            var list = _table.Find(id);
            if (list != null)
            {
                _dbcontext.Remove(list);
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
        }



        public T Update(T item)
        {
            _table.Update(item);
            _dbcontext.SaveChanges();
            return item;
        }

        public T? GetById(int id)
        {
            T? item = _table.Find(id);
            return item;
        }
    }
}
