using Microsoft.EntityFrameworkCore;
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
        public List<TodoList> GetAllList()
        {
            using (TodoListDbContext _dbcontext = new TodoListDbContext())
            {
                return _dbcontext.TodoList.Where<TodoList>(L => L.Open == true).ToList<TodoList>();
            }
        }

        public bool DeleteList(int id)
        {
            throw new NotImplementedException();
        }

      

        public TodoList UpdateList(TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
