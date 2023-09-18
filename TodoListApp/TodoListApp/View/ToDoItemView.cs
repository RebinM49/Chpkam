using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.View
{
    public class ToDoItemView : IView ,IListView
    {
        
        public void RunView()
        {
            CommonOutputTexts.GenerateHeading("ToDo Item Menu");
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
