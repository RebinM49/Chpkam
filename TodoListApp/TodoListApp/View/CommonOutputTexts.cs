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
        public static void GenerateHeading (string text)
        {
            
            var heading = $"ToDo App \n {text} \n";
            var border = new String('-',heading.Length );
            Console.WriteLine($"{border}\n{heading}{border}");
        }

        

        public static void DisplayOperationMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Operations : \n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[1] Create new List \t [2] Show ToDo Lists \t [3] Close a List \t [4] Add ToDo Item" +
                $"\t [5] Done Item");
            Console.ResetColor();

            
        }
    }
}
