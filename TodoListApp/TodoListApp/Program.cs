using Microsoft.EntityFrameworkCore.Internal;
using TodoListApp.Data;
using TodoListApp.Model;
using TodoListApp.View;

IRegister<ToDoList> register = new Register<ToDoList>();
IListView listview =new ListView(register);
IView mainView = new MainView(listview);
mainView.RunView();
Console.ReadKey();