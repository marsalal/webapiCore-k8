using System.Collections.Generic;
using webApik8.Models;

namespace webApik8.Services
{
    public interface ITodoService
    {
         IList<Todo> TodoList {get;}
         void Add(Todo item);
         void Update(Todo item, string id);
         bool Delete(string id);
         Todo GetItem(string id);

         IEnumerable<Todo> GetAllItems();
    }
}