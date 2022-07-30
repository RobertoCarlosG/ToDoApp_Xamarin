using System;
using SQLite;
using System.Threading.Tasks;
using ToDoList.App.View;
using ToDoList.App.Models;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.App.Data
{
    public class DataBaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }
        public DataBaseContext(string path) {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<ToDoItem>().Wait();
        }
        public async Task<int> InsertItemAsync(ToDoItem item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<List<ToDoItem>> GetItemsAsync()
        {
            return await Connection.Table<ToDoItem>().ToListAsync();
        }

        public async Task<int> DeleteItemAsync(ToDoItem item)
        {
            return await Connection.DeleteAsync(item);
        }
    }
}
