using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Model
{
    public class TodoItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public int EstimatedTime { get; set; }
        public int SpendTime { get; set; }
        public Importance Priority { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateDeleted { get; set; }

        public int ListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}
