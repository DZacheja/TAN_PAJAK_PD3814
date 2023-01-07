using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WarehouseAPI.Models;
using WarehouseAPI.Services;

namespace WarehouseAPI.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private IDatabaseService _databaseService;

        public WarehousesController(IDatabaseService databaseService)
        {
            _databaseService = databaseService; 
        }

        [HttpPut]
        public async Task<IActionResult> RegisterNewProduct([FromBody]NewProduct product)
        {
            try
            {
                int productID = await _databaseService.RegisterNewProduct(product);
                return Ok(productID);
            }catch(NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
