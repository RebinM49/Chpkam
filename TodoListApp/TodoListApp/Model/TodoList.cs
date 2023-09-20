using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Model
{
    public class ToDoList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } 
        public bool Open { get; set; }
        public String? Description { get; set; }
        

        public virtual List<ToDoTask> Tasks { get; set; }

        
    }
}
