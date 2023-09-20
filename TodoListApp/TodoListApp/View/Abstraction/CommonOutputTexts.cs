using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.View
{
    public static class CommonOutputTexts
    {
        public static void GenerateHeading(string text)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var heading = new string("ToDo List App");
            var border = new String('-', Console.WindowWidth);
            Console.WriteLine($"{border}\n\t\t\t{heading}\n{border}");
            Console.ResetColor();
        }



        public static void DisplayOperationMenu()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nOperations :");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[1] Create new List \t [2] Show ToDo Lists \t [3] Close a List \t [4] Add ToDo Item \t [5] Show ToDo Task" +
                $"\t [6] Done Item");
            Console.ResetColor();
        }

        public static void Write_UI_Title(string text)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{text} :  ");
            Console.ResetColor();
        }
        public static void Write_UI_values(string value)
        {
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.Write(value+"\n");
            Console.ResetColor();
        }

        public static void Write_system_messages(string message)
        {
            Console.ResetColor();
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void App_UI_headings(string message)
        {
            Console.ResetColor();
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string arrows = "\t<-> <-> <->\t";
            Console.WriteLine($"{arrows}{message}{arrows}\n");
            Console.ResetColor();
        }
    }
}
