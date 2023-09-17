using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    public interface IRegisterList
    {
        public bool AddList(ToDoList todoList);
        public bool DeleteList(int id);
        public ToDoList UpdateList(ToDoList todoList);
        public List<ToDoList> GetAllList();
    }
}
