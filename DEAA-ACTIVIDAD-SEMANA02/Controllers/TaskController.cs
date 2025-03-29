using Microsoft.AspNetCore.Mvc;
using Task = DEAA_ACTIVIDAD_SEMANA02.Models.Task;

namespace DEAA_ACTIVIDAD_SEMANA02.Controllers
{
    [Route("api/Miguel/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static readonly List<Task> Tarea = new();
        
        
        [HttpPost]
        public IActionResult CrearTask([FromBody] Task task)
        {
            task.StartDate = task.StartDate == default ? DateTime.Now : task.StartDate;
            Tarea.Add(task);
            return Ok("Task registrada exitosamente.");
        }
        
        [HttpGet]
        public IActionResult ObtenerTasks()
        {
            return Ok(Tarea);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerTask(int id)
        {
            var task = Tarea.FirstOrDefault(x => x.Id == id);
            return Ok(task);
        }
        
        [HttpDelete("{id}")]
        public IActionResult EliminarTask(int id)
        {
            var task = Tarea.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound("Task no encontrada.");

            Tarea.Remove(task);
            return Ok("Task eliminada correctamente.");
        }
        
        [HttpPut("{id}")]
        public IActionResult ReemplazarTask(int id, [FromBody] Task nuevaTask)
        {
            var index = Tarea.FindIndex(t => t.Id == id);
            if (index == -1) return NotFound("Task no encontrada.");

            nuevaTask.Id = id;
            Tarea[index] = nuevaTask;
            return Ok("Task reemplazada correctamente.");
        }
        
        [HttpPut("update/{id}")]
        public IActionResult ActualizarTask(int id, [FromBody] Task taskActualizada)
        {
            var task = Tarea.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound("Task no encontrada.");

            task.Title = taskActualizada.Title ?? task.Title;
            task.Status = taskActualizada.Status ?? task.Status;
            task.StartDate = taskActualizada.StartDate != default ? taskActualizada.StartDate : task.StartDate;
            task.EndDate = taskActualizada.EndDate != default ? taskActualizada.EndDate : task.EndDate;

            return Ok("Task actualizada correctamente.");
        }
        
        [HttpPatch("{id}")]
        public IActionResult ActualizarStatus(int id, [FromBody] string nuevoStatus)
        {
            var task = Tarea.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound("Task no encontrada.");

            task.Status = nuevoStatus;
            return Ok("Status de la Task actualizado correctamente.");
        }
    }
}

