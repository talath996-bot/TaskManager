using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Id=1,
                Title = "Study C#",
                Description="Review OOP",
                IsCompleted=false
            },

            new TaskItem
            {
                Id=2,
                Title = "Studt ASP .Net Core",
                Description="Learn Web",
                IsCompleted=false
            }
        };
        [HttpGet]
        public List<TaskItem> Get()
        {

            return tasks;
        }

        [HttpPost]
        public TaskItem Add(TaskItem task)
        { 
            tasks.Add(task);
            return task;
        }

        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetById(int id) 
        { 
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if(task == null) return NotFound();
            return task;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(x=> x.Id == id);
            if (task == null) return NotFound();

            tasks.Remove(task);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(x=> x.Id == id);
            if(task==null) return NotFound();
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.IsCompleted = updatedTask.IsCompleted;
            return NoContent();
        }
    }
    
}
