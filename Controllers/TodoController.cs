using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAngularStorm.Models;
using WebApiAngularStorm.Services;

namespace WebApiAngularStorm.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
      private readonly ApiContext _context;

      public TodosController (ApiContext context)
      {
        _context = context;
      }

     [HttpGet]
     public IActionResult Get()
     {
       return Ok(_context.Todos.ToList());
     } 

     [HttpGet("{id}", Name = "GetTodo")]
     public IActionResult GetById(int id)
     {
       return Ok(_context.Todos.SingleOrDefault(td => td.Id == id));
     }
     public IActionResult Post([FromBody] Todo todo)
     {
       if(todo.Id > 0)
       {
         _context.Entry(todo).State = EntityState.Modified;
       }
       else
       {
         _context.Add(todo);
       }
       _context.SaveChanges();
       return CreatedAtRoute("GetTodo", new {id=todo.Id}, todo);
     }

     [HttpDelete("{id}")]
     public IActionResult Delete(int id)
     {
       _context.Todos.Remove(_context.Todos.FirstOrDefault(todo => todo.Id == id));
       _context.SaveChanges();
       return Ok();
     }

    }
}