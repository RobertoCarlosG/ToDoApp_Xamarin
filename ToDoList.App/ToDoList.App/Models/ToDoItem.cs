using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoList.App.Models
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
