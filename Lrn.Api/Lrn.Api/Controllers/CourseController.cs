using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lrn.Aplication.Facades;
using Lrn.Aplication.Interfaces;
using Lrn.Aplication.ModelQuery;
using Lrn.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lrn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseFacade facade;

        public CourseController(ICourseFacade facade)
        {
            this.facade = facade;
        }

        /// <summary>
        /// Search courses
        /// </summary>
        /// <param name="query">the serach query like: {"query": "{course(name: \"Programação\") {name,description,created}}"} </param>
        /// <returns>A list of courses that match given criteria</returns>
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Find([FromBody] GraphQLQuery query)
        {
            try
            {
                var content = await facade.FindAsync(query);

                return new ObjectResult(content);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Course item)
        {
            try
            {
                facade.Insert(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Course item)
        {
            try
            {
                facade.Update(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                facade.Delete(id);

                return new NoContentResult();
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
        
        [HttpGet("home")]
        public IActionResult Home()
        {
            try
            {
                return new ObjectResult(facade.ListHome());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("full/{id}")]
        public IActionResult GetFull(int id)
        {
            try
            {
                return new ObjectResult(facade.GetFull(id));
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