using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            item.Title = CommonInputTexts.GetStringInput("Enter Title");
            item.EstimatedTime = CommonInputTexts.GetIntInput("Enter estimated Time");
            item.Priority = CommonInputTexts.GetStringInput("Enter task priority ( low - medium - high")
                .ToEnum<Importance>(Importance.Medium);
            item.ToDolistId = CommonInputTexts.GetIntInput("Enter parent list id");
            AddItem(item);

        }
        private void AddItem(ToDoTask item)
        {
            try
            {
                _repository.Add(item);
                CommonOutputTexts.Write_system_messages("New Task Added , GoodLuck");
            }
            catch (Exception e)
            {
                CommonOutputTexts.Write_system_messages("The parent id you entered dose not exists");
                CommonOutputTexts.Write_system_messages(e.Message);

            }
        }
        /// <summary>
        /// Generates the UI for show all task related to specific list
        /// </summary>
        public void DisplayAllSectionUI()
        {
            CommonOutputTexts.App_UI_headings("This is your ToDo Lists");

            var items = _repository.GetAll();
            foreach (var item in items)
            {
                if (item.Done is false)
                {
                    CommonOutputTexts.Write_UI_Title("Parent Id");
                    CommonOutputTexts.Write_UI_values($"\t{item.ToDolistId}");
                    CommonOutputTexts.Write_UI_Title("\tId");
                    CommonOutputTexts.Write_UI_values($"\t{item.Id}");
                    CommonOutputTexts.Write_UI_Title("\tTitle");
                    CommonOutputTexts.Write_UI_values($"\t{item.Title}");
                    CommonOutputTexts.Write_UI_Title("\tEstimated Time");
                    CommonOutputTexts.Write_UI_values($"\t{item.EstimatedTime}");
                    CommonOutputTexts.Write_UI_Title("\tPriotiry");
                    CommonOutputTexts.Write_UI_values($"\t{item.Priority}");
                }
                Console.WriteLine("\n");
            }
        }

        public void DisplayDeleteSectionUI()
        {

        }
        /// <summary>
        /// Generates the UI for Updateing a Task 
        /// </summary>
        public void DisplayUpdateSecionUI()
        {
            CommonOutputTexts.App_UI_headings("Task Completion Status");

            var task = GetToDoTask();
            if (task is not null)
            {
                var status = CommonInputTexts.GetStringInput("Enter status ( done - undone )");
                task.Done = CheckforDone(status);
                UpdateTask(task);
            }
            else
            {
                CommonOutputTexts.Write_system_messages("Id was not correct ! :)");
            }
        }

        /// <summary>
        /// recives user input string and checks if value is "done" or not.just check for "done" .
        /// </summary>
        /// <param name="status">user input string</param>
        /// <returns></returns>
        private bool CheckforDone(string status)
        {
            if (status == "done")
                return true;
            return false;
        }

        /// <summary>
        /// Recives a TodoTask object and update the repository if possible.Shows realated error !
        /// </summary>
        /// <param name="task">Object of type ToDoTask to update database with.</param>
        private void UpdateTask(ToDoTask task)
        {
            try
            {
                _repository.Update(task);
                CommonOutputTexts.Write_system_messages("Task Updated");
            }
            catch (Exception e)
            {
                CommonOutputTexts.Write_system_messages("This task cannot be Updated !");
                CommonOutputTexts.Write_system_messages($"More detail :\n {e.Message} ");
            }
        }

        /// <summary>
        /// Display details of a specific Task . 
        /// </summary>
        public void DisplaySingleItemSectionUI()
        {
            CommonOutputTexts.App_UI_headings("Task's Detail");
            var item = GetToDoTask();
            if (item is not null)
            {
                CommonOutputTexts.Write_UI_Title("Task Id");
                CommonOutputTexts.Write_UI_values(item.Id.ToString());
                CommonOutputTexts.Write_UI_Title("Task Title");
                CommonOutputTexts.Write_UI_values($"{item.Title}");
                CommonOutputTexts.Write_UI_Title("Task Priority");
                CommonOutputTexts.Write_UI_values($"{item.Priority}");
                CommonOutputTexts.Write_UI_Title("Task EstimatedTime");
                CommonOutputTexts.Write_UI_values($"{item.EstimatedTime}");
                CommonOutputTexts.Write_UI_Title("Task Status");
                CommonOutputTexts.Write_UI_values(item.Done.ToString());
            }
            CommonOutputTexts.Write_system_messages("This task dose not exists !");
        }
        /// <summary>
        /// Get Task Id from user. Get related Task from repository if exists. 
        /// </summary>
        /// <returns>ToDoTask with given Id or Null</returns>
        private ToDoTask GetToDoTask()
        {
            int id = CommonInputTexts.GetIntInput("Enter Task's related Id");
            ToDoTask task = null;
            try
            {
                task = _repository.GetById(id);
            }
            catch (Exception ex)
            {
                CommonOutputTexts.Write_system_messages("Id is invalid");
                CommonOutputTexts.Write_system_messages($"More detail :\n {ex.Message}");
            }
            return task;
        }
    }
}
