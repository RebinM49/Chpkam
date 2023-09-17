using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data;
using TodoListApp.Model;

namespace TodoListApp.View
{
    public  class MainView : IView
    {

        IListView _listview;

        public MainView(IListView listview)
        {

            _listview = listview;
        }
        public void RunView()
        {
            CommonOutputTexts.GenerateHeading("Menu");
            CommonOutputTexts.DisplayOperationMenu();
            GetOperationType();
        }

        private void GetOperationType()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Choose Operation type :\t");
            Console.ResetColor();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DisplayCreateList();
                    break;
                case "2":
                    DisplayLists();
                    break;
                case "3":
                    ShowList();
                    break;
                case "4":
                    ShowList();
                    break;
            }
        }

        private void ShowList()
        {

            Console.WriteLine("\t 2");
        }

        private void DisplayLists()
        {
            _listview.DisplayListsSectionUI();
        }
        private void DisplayCreateList()
        {
            _listview.DisplayAddListUI();
            this.GetOperationType();
        }
    }
}
