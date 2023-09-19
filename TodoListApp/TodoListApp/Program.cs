using Microsoft.EntityFrameworkCore.Internal;
using TodoListApp.Data;
using TodoListApp.Model;
using TodoListApp.View;

IGenericRepository<ToDoList> registerList = new GenericRepository<ToDoList>();
IGenericRepository<ToDoItem> registerItem = new GenericRepository<ToDoItem>();
IListView listView =new ListView(registerList);
IListView itemView =new ToDoItemView(registerItem);
IView mainView = new MainView(listView,itemView);
mainView.RunView();
Console.ReadKey();