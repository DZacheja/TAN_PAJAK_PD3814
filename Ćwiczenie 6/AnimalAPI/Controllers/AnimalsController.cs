using AnimalAPI.Models;
using AnimalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalAPI.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IDbService _dbService { get; set; }
        public AnimalsController(IDbService dbService)
        {
            this._dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            return Ok(await _dbService.GetAnimals());
        }

        [HttpGet("{animalId}")]
        public async Task<IActionResult> GetAnimal(int animalId)
        {
            var animal = await _dbService.GetAnimal(animalId);
            if (animal != null)
                return Ok(animal);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] Animal animal)
        {
            var newAnimal = await _dbService.CreateAnimal(animal);

            if (newAnimal != null)
                return Ok(newAnimal);
            else
                return StatusCode(500); //Internal Server Error
        }

        [HttpPut("{animalID}")]
        public async Task<IActionResult> CreateAnimal([FromBody] Animal animal, [FromRoute] int animalID)
        {
            var updateAnimal = await _dbService.UpdateAnimal(animal,animalID);

            if (updateAnimal != null)
                return Ok(updateAnimal);
            else
                return NotFound(); 
        }


        [HttpDelete("{animalID}")]
        public async Task<IActionResult> CreateAnimal([FromRoute] int animalID)
        {
            var res = await _dbService.DeleteAnimal(animalID);

            if (res == 1)
                return NoContent();
            else
                return NotFound(); 
        }
    }
}
