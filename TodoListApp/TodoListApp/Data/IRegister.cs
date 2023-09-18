using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    public interface IRegister<T> where T : class
    {
        public bool Add(T todoList);
        public bool Delete(int id);
        public T Update(T todoList);
        public List<T> GetAll();
    }
}
