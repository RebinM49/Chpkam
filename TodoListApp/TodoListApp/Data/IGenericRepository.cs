using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    public interface IGenericRepository<T> where T : class
    {
        public bool Add(T item);
        public bool Delete(int id);
        public T Update(T item);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
    }
}
