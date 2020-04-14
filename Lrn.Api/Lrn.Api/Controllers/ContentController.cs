using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lrn.Aplication.Facades;
using Lrn.Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lrn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentFacade facade;

        public ContentController(IContentFacade facade)
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