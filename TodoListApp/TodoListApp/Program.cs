using Microsoft.EntityFrameworkCore.Internal;
using TodoListApp.Data;
using TodoListApp.Model;
using TodoListApp.View;
using TodoListApp.View.Abstraction;

IGenericRepository<ToDoList> registerList = new GenericRepository<ToDoList>();
IGenericRepository<ToDoTask> registerItem = new GenericRepository<ToDoTask>();
IListView listView =new ListView(registerList);
IListView itemView =new ToDoTaskView(registerItem);
IView mainView = new MainView(listView,itemView);
mainView.RunView();
Console.ReadKey();