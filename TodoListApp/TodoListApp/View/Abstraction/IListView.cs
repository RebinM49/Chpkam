using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.View.Abstraction
{
    public interface IListView
    {
        public void DisplayDeleteSectionUI();
        public void DisplayAllSectionUI();
        public void DisplayAddSectionUI();
        public void DisplayUpdateSecionUI();
        public void DisplaySingleItemSectionUI();
    }
}
