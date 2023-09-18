using Microsoft.EntityFrameworkCore.Internal;
using TodoListApp.Data;
using TodoListApp.View;

IRegisterList register = new RegisterList();
IListView listview =new ListView(register);
IView mainView = new MainView(listview);
mainView.RunView();
Console.ReadKey();