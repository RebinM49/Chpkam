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
        IGenericRepository<ToDoList> _registerList;

        public ListView(IGenericRepository<ToDoList> registerList)
        {
            _registerList = registerList;
        }

        public static void RunView()
        {
            CommonOutputTexts.GenerateHeading("List Menu");
        }

        public void DisplayDeleteSectionUI()
        {
            CommonOutputTexts.Write_UI_Title("Enter the Id of list you want to delete : ");
            int id;
            bool success = int.TryParse(Console.ReadLine(), out id);
            if (success)
            {
                bool deleted = _registerList.Delete(id);
                if (deleted)
                {
                    CommonOutputTexts.Write_system_messages($"List by {id} deleted");
                }
                else
                {
                    CommonOutputTexts.Write_system_messages("id out of range! ");
                }
            }
            else
            {
                CommonOutputTexts.Write_system_messages("The Id you entered is invalid");
            }
        }

        public void DisplayAllSectionUI()
        {
            
            CommonOutputTexts.App_UI_headings("This is your ToDo Lists");
            var lists = _registerList.GetAll();

            foreach (var list in lists)
            {
                if (list.Open)
                {
                    CommonOutputTexts.Write_UI_Title("Id");
                    CommonOutputTexts.Write_UI_values($"{list.Id}");
                    CommonOutputTexts.Write_UI_Title("Title");
                    CommonOutputTexts.Write_UI_values($"{list.Title}");
                    CommonOutputTexts.Write_UI_Title("Description");
                    CommonOutputTexts.Write_UI_values($"{list.Description}");

                    foreach (var task in list.Tasks)
                    {
                        CommonOutputTexts.Write_UI_Title("ToDo Items");
                        CommonOutputTexts.Write_UI_values($"{task.Id} {task.Title}");

                    }
                }
                Console.WriteLine("\n");
            }
            
        }

        public void DisplayAddSectionUI()
        {  
            var list = new ToDoList();
            CommonOutputTexts.Write_UI_Title("Enter Title for new List");
            list.Title = Console.ReadLine();

            CommonOutputTexts.Write_UI_Title("Enter description for new list");
            list.Description = Console.ReadLine();

            CommonOutputTexts.Write_UI_Title("Enter status for new list");
            list.Open = (Console.ReadLine().ToLower()) == "open" ? true : false;

            _registerList.Add(list);
        }
    }
}
