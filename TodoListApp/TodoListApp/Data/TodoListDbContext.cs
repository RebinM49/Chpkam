using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    public class TodoListDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}TodolistApp.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<ToDoTask> TodoItem { get; set; }
    }
}
