using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data;
using TodoListApp.Model;

namespace TodoListApp.View
{
    public class ToDoItemView : IView ,IListView
    {
        IGenericRepository<ToDoItem> _repository;
        public ToDoItemView(IGenericRepository<ToDoItem> repository)
        {
            _repository = repository;
        }
        public void RunView()
        {
            CommonOutputTexts.App_UI_headings("ToDo Item Menu");
        }
        public void DisplayAddSectionUI()
        {
            throw new NotImplementedException();
        }

        public void DisplayAllSectionUI()
        {
            throw new NotImplementedException();
        }

        public void DisplayDeleteSectionUI()
        {
            throw new NotImplementedException();
        }

        
        
    }
}
