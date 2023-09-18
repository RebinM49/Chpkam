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
    public class ListView : IListView
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

        public void DisplayDeleteSectionUI()
        {
            Console.WriteLine("Enter the Id of list you want to delete : ");
            int id;
            bool success = int.TryParse(Console.ReadLine(),out id);
            if (success)
            {
                bool deleted =_registerList.DeleteList(id);
                if (deleted)
                {
                    Console.WriteLine($"List by {id} deleted");
                }
                else
                {
                    Console.WriteLine("id out of range! ");
                }
            }
            else
            {
                Console.WriteLine("The Id you Entered is invalid");
            }
        }

        public void DisplayUpdateSectionUI()
        {
            throw new NotImplementedException();
        }

        public void DisplayListsSectionUI()
        {
            Console.ResetColor();
            Console.WriteLine("\t<-> <->  This is your ToDo Lists <-> <->");
            var lists = _registerList.GetAllList();

            foreach (var list in lists)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (list.Open)
                {
                    Console.WriteLine($"Id : {list.Id}\t Title : {list.Title}\t Description : {list.Description}\t");
                    foreach (var task in list.Tasks)
                    {
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine($"Item {task.Id}\t{task.Title}");
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void DisplayListSectionUI()
        {

        }

        public void DisplayAddListUI()
        {
            Console.ResetColor();
            var list = new ToDoList();
            Console.WriteLine("Enter Title for new List : ");
            list.Title = Console.ReadLine();

            Console.WriteLine("Enter description for new list : ");
            list.Description = Console.ReadLine();

            Console.WriteLine("Enter status for new list : ");
            list.Open = (Console.ReadLine().ToLower()) == "open" ? true : false;

            
            _registerList.AddList(list);

            


        }
    }
}
