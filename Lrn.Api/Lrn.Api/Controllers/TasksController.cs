using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lrn.Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lrn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ICourseTopicFacade courseTopicFacade;
        private readonly IContentFacade contentFacade;

        public TasksController(ICourseTopicFacade courseTopicFacade, IContentFacade contentFacade){
            this.courseTopicFacade = courseTopicFacade;
            this.contentFacade = contentFacade;
        }

        [HttpGet]
        public IActionResult GenerateContent()
        {
            try{
                courseTopicFacade.GenerateContent(0);
                var Result = new Dictionary<string, string>();
                Result.Add("Status", "OK");

                return new ObjectResult(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}