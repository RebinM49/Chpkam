using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.Model;
using TodoListApp.View.Abstraction;

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
            int _id = CommonInputTexts.GetIntInput("Enter the Id of list you want to delete");
            var success = _registerList.Delete(_id);
            if (success)
            {
                CommonOutputTexts.Write_system_messages($"List by {_id} deleted");
            }
            else
            {
                CommonOutputTexts.Write_system_messages($"List with {_id} dose not exists !");
            }
        }


        public void DisplayAllSectionUI()
        {
            CommonOutputTexts.App_UI_headings("This is your ToDo Lists");
            var lists = _registerList.GetAll();
            if (lists.Count() > 0)
            {
                foreach (var list in lists)
                {
                    CommonOutputTexts.Write_UI_Title("Id");
                    CommonOutputTexts.Write_UI_values($"{list.Id}");
                    CommonOutputTexts.Write_UI_Title("Title");
                    CommonOutputTexts.Write_UI_values($"{list.Title}");
                    CommonOutputTexts.Write_UI_Title("Description");
                    CommonOutputTexts.Write_UI_values($"{list.Description}");

                    foreach (var task in list.Tasks)
                    {
                        CommonOutputTexts.Write_UI_Title("ToDo Tasks");
                        CommonOutputTexts.Write_UI_values($"{task.Id} {task.Title}");
                    }
                }
                Console.WriteLine("\n");
            }
            else
                CommonOutputTexts.Write_system_messages("There is no list to show");
        }

        public void DisplayAddSectionUI()
        {
            var list = new ToDoList();
            list.Title = CommonInputTexts.GetStringInput("Enter Title for new List");
            list.Description = CommonInputTexts.GetStringInput("Enter description for new list");
            string status = CommonInputTexts.GetStringInput("Enter Status for new list ( open - close) ");
            list.Open = status.ToLower() == "open" ? true : false;
            AddList(list);

        }
        private void AddList(ToDoList list)
        {
            try
            {
                _registerList.Add(list);
                CommonOutputTexts.Write_system_messages($"new list with id of < {list.Id} > added");
            }
            catch (Exception ex)
            {
                CommonOutputTexts.Write_system_messages("This list cannot be created !");
                CommonOutputTexts.Write_system_messages($"More detail :\n {ex.Message}");
            }
        }

        public void DisplayUpdateSecionUI()
        {
            throw new NotImplementedException();
        }

        public void DisplaySingleItemSectionUI()
        {
            throw new NotImplementedException();
        }
    }
}
