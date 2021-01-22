using System;
using System.Collections.Generic;
using System.Linq;
using webApik8.Models;

namespace webApik8.Services
{
    public class TodoService : ITodoService
    {
        public IList<Todo> TodoList {get;}

        public TodoService()
        {
            TodoList = new List<Todo> { { new Todo { Id = Guid.NewGuid().ToString(), Description = "test", IsCompleted = false}}};
        }

        public void Add(Todo item)
        {
            if (!TodoList.Any(x => x.Id == item.Id))
            {
                TodoList.Add(item);
            }
        }

        public bool Delete(string id) => TodoList.Remove(TodoList.FirstOrDefault(x => x.Id == id));

        public IEnumerable<Todo> GetAllItems() => TodoList;

        public Todo GetItem(string id) => TodoList.FirstOrDefault(x => x.Id == id);

        public void Update(Todo item, string id)
        { 
            var todoItem = TodoList.FirstOrDefault(x => x.Id == id);
            if (todoItem != null)
            {
                todoItem.Description = item.Description;
                todoItem.IsCompleted = item.IsCompleted;
            }
        }
    }
}