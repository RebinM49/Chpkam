using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.View
{
    public interface IListView
    {
        public void DisplayListSectionUI();
        public void DisplayDeleteSectionUI();
        public void DisplayUpdateSectionUI();
        public void DisplayListsSectionUI();
        public void DisplayAddListUI();
    }
}
