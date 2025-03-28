﻿using CRUDReactMVC.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDReactMVC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly CrudreactMvcContext _context;

        public ContactoController(CrudreactMvcContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _context.Contactos.OrderByDescending(c => c.IdContacto).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("guardar")]

        public async Task<IActionResult> Guardar([FromBody] Contacto request)
        {
            await _context.Contactos.Add(request);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] ContactoController request)
        {
            _context.Contactos.Update(request);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        [Route("eliminar/(id:int)")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var contacto = _context.Contactos.FirstOrDefault(c => c.IdContacto == id);

            if(contacto != null)
            {
                _context.Remove(contacto);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
