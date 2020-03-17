using System;
using Lrn.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lrn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionFacade facade;

        public SectionController(ISectionFacade facade)
        {
            this.facade = facade;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return new ObjectResult(facade.List());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(facade.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}