using System;
using System.Collections.Generic;
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
    }
}
