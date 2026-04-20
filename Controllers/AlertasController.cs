using Microsoft.AspNetCore.Mvc;
using NanoGuardian.Api.Models;

namespace NanoGuardian.Api.Controllers
{
    [ApiController]           // Indica que esta clase es una API
    [Route("api/[controller]")] // La URL será: http://localhost:xxxx/api/alertas
    public class AlertasController: ControllerBase
    {
            [HttpGet]
            public IActionResult ObtenerAlerta()
            {
                var datos = new 
                { 
                    Distancia = 25.5f, 
                    AlertaCaida = false 
                };
        
                // Esto obliga a que se envíen con Mayúscula
                return new JsonResult(datos);;
            }
            
            // El verbo POST se usa para RECIBIR y CREAR nuevos datos
            [HttpPost]
            public IActionResult RecibirAlerta([FromBody] Alerta nuevaAlerta)
            {
                // Validamos que los datos no vengan vacíos
                if (string.IsNullOrEmpty(nuevaAlerta.Paciente))
                {
                    return BadRequest("El nombre del paciente es obligatorio."); // HTTP 400
                }

                // Simulamos que guardamos en base de datos imprimiendo en consola
                Console.WriteLine($"🚨 ALERTA RECIBIDA: Paciente {nuevaAlerta.Paciente} cayó con {nuevaAlerta.FuerzaImpactoG}G");

                // Respondemos al dispositivo que todo salió bien
                return Ok(new { mensaje = "Alerta procesada con éxito", codigo = 200 }); // HTTP 200
            }
    }
}
