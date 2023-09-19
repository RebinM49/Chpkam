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
            return _table.ToList();
        }

        public bool Delete(int id)
        {
            

            var list = _dbcontext.ToDoList.Find(id);
            if (list != null)
            {
                _dbcontext.ToDoList.Remove(list);
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

        T IGenericRepository<T>.GetById(int id)
        {
            return _table.Find(id);
        }
    }
}
