using TodoListApp.View.Abstraction;

namespace TodoListApp.View
{
    public class MainView : IView
    {

        IListView _listview;
        IListView _itelview;

        public MainView(IListView listview, IListView itemview)
        {
            _itelview = itemview;
            _listview = listview;
        }
        public void RunView()
        {
            CommonOutputTexts.GenerateHeading("Menu");
            GetOperationType();
        }

        private void GetOperationType()
        {

            CommonOutputTexts.DisplayOperationMenu();
            CommonOutputTexts.Write_UI_Title("Enter operation code");

            var input = Console.ReadLine();


            switch (input)
            {
                case "1":
                    DisplayAddList();
                    break;
                case "2":
                    DisplayLists();
                    break;
                case "3":
                    DisplayCloseList();
                    break;
                case "4":
                    DisplayAddToDoTask();
                    break;
                case "5":
                    DisplayToDoTasks();
                    break;
                case "6":
                    DisplayCheckTask();
                    break;
                case "7":
                    DisplaySpecificTask();
                    break;
                default:
                    CommonOutputTexts.Write_system_messages("Enter Valid number!");
                    GetOperationType();
                    break;
            }

        }


        private void DisplayCloseList()
        {
            _listview.DisplayDeleteSectionUI();
            GetOperationType();
        }

        private void DisplayLists()
        {
            _listview.DisplayAllSectionUI();
            GetOperationType();
        }
        private void DisplayAddList()
        {
            _listview.DisplayAddSectionUI();
            this.GetOperationType();
        }
        private void DisplayAddToDoTask()
        {
            _itelview.DisplayAddSectionUI();
            GetOperationType();
        }
        private void DisplayToDoTasks()
        {
            _itelview.DisplayAllSectionUI();
            GetOperationType();
        }
        private void DisplayCheckTask()
        {
            _itelview.DisplayUpdateSecionUI();
            GetOperationType();
        }
        private void DisplaySpecificTask()
        {
            _itelview.DisplaySingleItemSectionUI();
            GetOperationType();
        }
    }
}
