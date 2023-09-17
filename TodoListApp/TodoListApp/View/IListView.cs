using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.View
{
    public interface IListView
    {
        public void DisplayListSection();
        public void DisplayDeleteSection();
        public void DisplayUpdateSection();
        public void DisplayListsSection();
    }
}
