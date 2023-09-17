using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.Model;

namespace TodoListApp.View
{
    public class ListView :  IListView
    {
        IRegisterList _registerList;

        public ListView(IRegisterList registerList)
        {
            _registerList = registerList;
        }
        public static void RunView()
        {
            CommonOutputTexts.GenerateHeading("List Menu");
        }

        public void DisplayDeleteSection()
        {
            throw new NotImplementedException();
        }

        public void DisplayListSection()
        {
            throw new NotImplementedException();
        }

        public void DisplayUpdateSection()
        {
            throw new NotImplementedException();
        }


        public void DisplayListsSection()
        {
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            var lists = _registerList.GetAllList();
            var sublist = lists.Select(x => x.Tasks);
            foreach (var list in lists)
            {
                
                if (list.Open)
                {
                    Console.WriteLine($"Title : {list.Title}\t Description : {list.Description}" +
                    $"\t{list.Tasks.First<ToDoItem>().Title}");
                }
                
                
            }
            Console.ResetColor();
        }  
    }
}
