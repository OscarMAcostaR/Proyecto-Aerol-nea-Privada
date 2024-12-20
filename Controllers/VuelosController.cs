using Aeropuerto_WingsAir_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsAir_API.Dependency;
using WingsAir_API.Models;
using WingsAir_API.Services;

namespace WingsAir_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        //creo variables par ami servicio y mi contexto
        private readonly Aeropuerto_WingsAirContext _context;
        private readonly IVuelos _service;

        //inicializo mis variables
        public VuelosController(Aeropuerto_WingsAirContext context, IVuelos service)
        {
            _context = context;
            _service = service;
        }

        //GET
        [HttpGet]
        [Route("getVuelos")]
        public List<Vuelos_DTO> GetVuelos()
        {
            return _service.GetVuelos();
        }
        //GET
        [HttpGet]
        [Route("GetVuelosfiltered")]
        public List<Vuelos_DTO> GetVuelosfiltered(enum_vuelos filter)
        {
            return _service.GetVuelosfiltered(filter);
        }
        //GETbyID
        [HttpGet]
        [Route("GetVuelo")]
        public Vuelos_DTO GetVuelo(int id)
        {
            return _service.GetVuelo(id);
        }
        //POST
        [HttpPost]
        [Route("insertVuelo")]
        public IActionResult insertVuelo([FromBody] Vuelos_DTO vuelo)
        {
            string respuesta = _service.insertVuelo(vuelo);
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                return BadRequest("Ha Ocurrido un error: " + respuesta);
            }
            return Ok(new { respuesta });
        }
        //PUT
        [HttpPost]
        [Route("updateVuelo")]
        public IActionResult updateVuelo([FromBody] Vuelos_DTO vuelo)
        {
            string respuesta = _service.updateVuelo(vuelo);
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                return BadRequest("Ha Ocurrido un error: " + respuesta);
            }
            return Ok(new { respuesta });
        }
        //DELETE
        [HttpDelete]
        [Route("deleteVuelo")]
        public IActionResult deleteVuelo(int id)
        {
            string respuesta = _service.deleteVuelo(id);
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                return BadRequest("Ha Ocurrido un error: " + respuesta);
            }
            return Ok(new { respuesta });
        }
    }
}
