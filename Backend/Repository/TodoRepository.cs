using Backend.Contexts;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class TodoRepository
    {
        private ApplicationDbContext _dbcontext;

        public TodoRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<string> Create(Todo todo)
        {
            _dbcontext.Todo.Add(todo);
            await _dbcontext.SaveChangesAsync();
            return "TODO creado";
        }

        public async Task<string> Update(int id, Todo todo)
        {
            if (id != todo.Id) return "TODO no existe";
            _dbcontext.Update(todo);
            await _dbcontext.SaveChangesAsync();
            return "TODO modificado";
        }

        public async Task<string> Delete(int id)
        {
            var todo = await _dbcontext.Todo.FindAsync(id);
            if (todo == null) return "TODO no existe";
            _dbcontext.Todo.Remove(todo);
            await _dbcontext.SaveChangesAsync();
            return "TODO eliminado";
        }

        public async Task<List<Todo>> GetAll()
        {
            var todos = await _dbcontext.Todo.ToListAsync();
            return todos;
        }

        public async Task<Todo> GetById(int id)
        {
            var todo = await _dbcontext.Todo.FindAsync(id);
            return todo;
        }

        public async Task<List<Todo>> GetByDesc(string desc)
        {
            var todos = await _dbcontext.Todo.Where(x => x.Descripcion == desc).ToListAsync();
            return todos;
        }

        public async Task<List<Todo>> GetByState(string state)
        {
            var todos = await _dbcontext.Todo.Where(x => x.Estado == state).ToListAsync();
            return todos;
        }
    }
}
