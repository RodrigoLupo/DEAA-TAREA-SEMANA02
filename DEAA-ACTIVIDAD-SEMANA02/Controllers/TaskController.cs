
using Microsoft.AspNetCore.Mvc;

namespace DEAA_ACTIVIDAD_SEMANA02.Controllers
{
    [Route("api/Miguel/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static readonly List<Task> Tarea = new():


        [HttpPost]
        public IActionResult CrearTask([FromBody] Dictionary<string, object> task)
        {
            task["Id"] = contadorId++;
            tasks.Add(task);
            return Ok("Task registrada exitosamente.");
        }

        [HttpGet]
        public IActionResult ObtenerTasks()
        {
            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarTask(int id)
        {
            var task = tasks.FirstOrDefault(t => (int)t["Id"] == id);
            if (task == null) return NotFound("Task no encontrada.");

            tasks.Remove(task);
            return Ok("Task eliminada correctamente.");
        }

        [HttpPut("{id}")]
        public IActionResult ReemplazarTask(int id, [FromBody] Dictionary<string, object> nuevaTask)
        {
            var index = tasks.FindIndex(t => (int)t["Id"] == id);
            if (index == -1) return NotFound("Task no encontrada.");

            nuevaTask["Id"] = id;
            tasks[index] = nuevaTask;
            return Ok("Task reemplazada correctamente.");
        }


        [HttpPut("update/{id}")]
        public IActionResult ActualizarTask(int id, [FromBody] Dictionary<string, object> taskActualizada)
        {
            var task = tasks.FirstOrDefault(t => (int)t["Id"] == id);
            if (task == null) return NotFound("Task no encontrada.");

            foreach (var key in taskActualizada.Keys)
            {
                if (key != "Id") 
                    task[key] = taskActualizada[key];
            }

            return Ok("Task actualizada correctamente.");
        }
        
        [HttpPatch("{id}")]
        public IActionResult ActualizarCampo(int id, [FromBody] Dictionary<string, object> campoActualizado)
        {
            var task = tasks.FirstOrDefault(t => (int)t["Id"] == id);
            if (task == null) return NotFound("Task no encontrada.");

            foreach (var key in campoActualizado.Keys)
            {
                if (key != "Id")
                    task[key] = campoActualizado[key];
            }

            return Ok("Campo de Task actualizado correctamente.");
        }
    }
}
