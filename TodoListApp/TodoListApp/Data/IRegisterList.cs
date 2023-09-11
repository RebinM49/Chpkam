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
        bool DeleteList(TodoList todoList);
        bool UpdateList(TodoList todoList);
        bool GetList(TodoList todoList);
    }
}
