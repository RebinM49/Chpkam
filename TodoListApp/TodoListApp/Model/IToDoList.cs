using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Model
{
    internal interface IToDoList
    {
        public string Title { get; set; }
        public bool Open { get; set; }
        public String? Description { get; set; }
    }
}
