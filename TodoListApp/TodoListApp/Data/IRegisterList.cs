﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    internal interface IRegisterList
    {
        bool CreateList(TodoList todoList);
        bool DeleteList(int id);
        TodoList UpdateList(TodoList todoList);
        List<TodoList> GetList(TodoList todoList);
    }
}
