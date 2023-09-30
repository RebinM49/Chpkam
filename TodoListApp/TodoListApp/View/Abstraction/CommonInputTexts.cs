using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.View.Abstraction
{
    public static class CommonInputTexts
    {
        public static string GetStringInput(string outputMessage)
        {
            CommonOutputTexts.Write_UI_Title(outputMessage);
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                CommonOutputTexts.Write_system_messages("Enter a valid value");
                GetStringInput(outputMessage);
            }
            return input;
        }

        public static int GetIntInput(string outputMessage)
        {
            CommonOutputTexts.Write_UI_Title(outputMessage);
            string input = Console.ReadLine();

            int convertedValue;
            bool isNumber = int.TryParse(input, out convertedValue);
            if (string.IsNullOrEmpty(input) || !isNumber)
            {
                GetIntInput(outputMessage);
            }
            return convertedValue;

        }
    }
}
