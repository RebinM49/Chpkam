using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Model
{
    public class ToDoItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; } = false;
        public int? EstimatedTime { get; set; } = 20;
        public int? SpendTime { get; set; }
        public Importance Priority { get; set; } = Importance.Medium;

        public virtual ToDoList ToDoList { get; set; }
        public int ToDolistId { get; set; }
    }
}
