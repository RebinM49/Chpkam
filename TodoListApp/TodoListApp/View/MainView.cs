namespace TodoListApp.View
{
    public  class MainView : IView
    {

        IListView _listview;
        IListView _itelview;
        

        public MainView(IListView listview,IListView itemview)
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
                    DisplayAddToDoItem();
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
        private void DisplayAddToDoItem()
        {
            _itelview.DisplayAddSectionUI();
            GetOperationType();
        }
    }
}
