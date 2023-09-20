using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data;
using TodoListApp.Model;
using TodoListApp.View.Abstraction;

namespace TodoListApp.View
{
    public class ToDoTaskView : IView, IListView
    {
        IGenericRepository<ToDoTask> _repository;
        public ToDoTaskView(IGenericRepository<ToDoTask> todoItemRepo)
        {
            _repository = todoItemRepo;
        }
        public void RunView()
        {
            CommonOutputTexts.App_UI_headings("ToDo Item Menu");
        }
        public void DisplayAddSectionUI()
        {
            RunView();
            var item = new ToDoTask();
            CommonOutputTexts.Write_UI_Title("Enter Title");
            item.Title = Console.ReadLine();

            CommonOutputTexts.Write_UI_Title("Enter estimated Time");
            int estimatedTime;
            var estimatedInput = Console.ReadLine();
            int.TryParse(estimatedInput, out estimatedTime);

            CommonOutputTexts.Write_UI_Title("Enter task priority");
            var priorityValue = Console.ReadLine();
            priorityValue.ToEnum<Importance>(Importance.Medium);

            CommonOutputTexts.Write_UI_Title("Enter parent list id");
            int parentid;
            var parentIdValue = Console.ReadLine();
            int.TryParse(parentIdValue, out parentid);
            item.ToDolistId = parentid;
            _repository.Add(item);
        }

        public void DisplayAllSectionUI()
        {

            CommonOutputTexts.App_UI_headings("This is your ToDo Lists");
            var items = _repository.GetAll();
            foreach (var item in items)
            {
                if (!item.Done)
                {
                    CommonOutputTexts.Write_UI_Title("Parent Id");
                    CommonOutputTexts.Write_UI_values($"{item.Id}");
                    CommonOutputTexts.Write_UI_Title("Id");
                    CommonOutputTexts.Write_UI_values($"{item.Id}");
                    CommonOutputTexts.Write_UI_Title("Title");
                    CommonOutputTexts.Write_UI_values($"{item.Title}");
                    CommonOutputTexts.Write_UI_Title("Estimated Time");
                    CommonOutputTexts.Write_UI_values($"{item.EstimatedTime}");
                    CommonOutputTexts.Write_UI_Title("Priotiry");
                    CommonOutputTexts.Write_UI_values($"{item.Priority}");
                }
                Console.WriteLine("\n");
            }
        }

        public void DisplayDeleteSectionUI()
        {
            throw new NotImplementedException();
        }

        public void DisplayUpdateSecionUI()
        {
            CommonOutputTexts.App_UI_headings("Task Completion Status");
            CommonOutputTexts.Write_UI_Title("Eneter the Id of related Task");
            string inputId = Console.ReadLine();
            int id;
            int.TryParse(inputId, out id);
            var task = _repository.GetById(id);
            CommonOutputTexts.Write_UI_Title("Update Task status");
            string status = Console.ReadLine().ToLower();
            task.Done = status == "done" ? true : false;
            _repository.Update(task);
            CommonOutputTexts.Write_system_messages("Task Updated");
            DisplayAllSectionUI();
        }

        public void DisplaySingleItemSectionUI()
        {
            CommonOutputTexts.App_UI_headings("Task's Detail");
            var item = GetToDoItem();
            CommonOutputTexts.Write_UI_Title("Task Id");
            CommonOutputTexts.Write_UI_values(item.Id.ToString());
            CommonOutputTexts.Write_UI_Title("Task Status");
            CommonOutputTexts.Write_UI_values(item.Done.ToString());
        }
        private ToDoTask GetToDoItem()
        {
            CommonOutputTexts.Write_UI_Title("Enter Task's related Id");
            string inputId = Console.ReadLine();
            int id;
            int.TryParse(inputId, out id);
            var task = _repository.GetById(id);
            return task;
        }

    }
}
