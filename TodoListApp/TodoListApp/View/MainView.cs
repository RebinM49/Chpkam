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
                    DisplayCloseList();
                    break;
                case "4":
                    DisplayUpdateList();
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
            _listview.DisplayListsSectionUI();
            GetOperationType();
        }
        private void DisplayCreateList()
        {
            _listview.DisplayAddListUI();
            this.GetOperationType();
        }
        private void DisplayUpdateList()
        {
            _listview.DisplayUpdateSectionUI();
            GetOperationType();
        }
    }
}
