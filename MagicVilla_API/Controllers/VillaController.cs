using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private  readonly ILogger<VillaController> _logger;

        private readonly ApplicationDbContext _db;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {

            _logger = logger;
            _db = db;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las Villas");
            return Ok(_db.Villas.ToList());
        }
           
        [HttpGet("id:int", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if(id==0)
            {
                _logger.LogError("Error al traer Villa con Id " + id);
                return BadRequest();
            }
            //var Villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.FirstOrDefault(v=>v.Id == id);

            if(villa == null)
            {
                return NotFound();
            }

            return Ok(villa);   
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villa) 
        {
                
            if(!ModelState.IsValid)
            {   
                return BadRequest(ModelState);
            }

            if(_db.Villas.FirstOrDefault(v => v.Name.ToLower() == villa.Name.ToLower()) != null) 
            {
                ModelState.AddModelError("ErrorName", "La Villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }

            if(villa == null)
            {
                return BadRequest(villa);
            }
            
            if (villa.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa modelo = new()
            {
                Name = villa.Name,
                Description = villa.Description,
                ImageUrl = villa.ImageUrl,
                Occupants = villa.Occupants,
                Price = villa.Price,
                SquareMeter = villa.SquareMeter,
                Amenity = villa.Amenity
            };

            _db.Villas.Add(modelo);
            _db.SaveChanges();
            
            return CreatedAtRoute("GetVilla", new {id=villa.Id}, villa);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var villaId = _db.Villas.FirstOrDefault(v => v.Id == id);
            
            if(villaId == null)
            {
                return NotFound();
            }

           _db.Villas.Remove(villaId);
           _db.SaveChanges();

            return NoContent();

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {   
            if(villaDto== null || id!= villaDto.Id )
            {
                return BadRequest();
            }

            //var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            //villa.Name = villaDto.Name;
            //villa.Occupants = villaDto.Occupants;
            //villa.SquareMeter   = villaDto.SquareMeter;

            Villa modelo = new()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Description = villaDto.Description,
                Occupants = villaDto.Occupants,
                ImageUrl = villaDto.ImageUrl,
                Price = villaDto.Price,
                SquareMeter = villaDto.SquareMeter,
                Amenity = villaDto.Amenity
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();



        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            //var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);

            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Description = villa.Description,
                ImageUrl    = villa.ImageUrl,
                Price = villa.Price,  
                SquareMeter = villa.SquareMeter,
                Occupants = villa.Occupants,
                Amenity = villa.Amenity
            };

            if(villa ==null) return BadRequest();

            patchDto.ApplyTo(villaDto, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = new()
            {
                Id = villaDto.Id, 
                Name = villaDto.Name,
                Description = villaDto.Description,
                ImageUrl = villaDto.ImageUrl,
                Price = villaDto.Price,
                Occupants = villaDto.Occupants,
                SquareMeter = villaDto.SquareMeter,
                Amenity = villaDto.Amenity
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();



        }


    }
}
