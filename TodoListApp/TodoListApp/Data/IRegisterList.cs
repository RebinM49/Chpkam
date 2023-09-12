using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    internal interface IRegisterList
    {
        public bool CreateList(TodoList todoList);
        public bool DeleteList(int id);
        public TodoList UpdateList(TodoList todoList);
        public List<TodoList> GetAllList();
    }
}
