using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    public class RegisterList : IRegisterList
    {
        public bool CreateList(TodoList todoList)
        {
            using (TodoListDbContext _dbcontext = new TodoListDbContext())
            {
                _dbcontext.TodoList.Add(todoList);
                _dbcontext.SaveChanges();
               
            }
            return true;
        }

        public bool DeleteList(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public bool GetList(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateList(TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
