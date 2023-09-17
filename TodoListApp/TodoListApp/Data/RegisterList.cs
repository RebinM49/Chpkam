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
        public bool CreateList(ToDoList todoList)
        {
            using (TodoListDbContext _dbcontext = new TodoListDbContext())
            {
                _dbcontext.ToDoList.Add(todoList);
                _dbcontext.SaveChanges();
               
            }
            return true;
        }
        public List<ToDoList> GetAllList()
        {
            using (TodoListDbContext _dbcontext = new TodoListDbContext())
            {
                var list = _dbcontext.ToDoList.Include(p => p.Tasks).ToList();
                return list;
            }
        }

        public bool DeleteList(int id)
        {
            throw new NotImplementedException();
        }

      

        public ToDoList UpdateList(ToDoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}
